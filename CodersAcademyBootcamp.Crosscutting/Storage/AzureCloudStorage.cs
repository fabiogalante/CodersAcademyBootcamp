using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.Storage
{
    public class AzureCloudStorage
    {

        private string containerUrl;

        private static CloudBlobClient cloudBlobStorage;
        private static CloudBlobDirectory imagesDirectory;
        private string connectionString;
        
       
        public AzureCloudStorage(IOptions<AzureStorageOptions> options)
        {
            this.connectionString = options.Value.ConnectionString;
            this.containerUrl = options.Value.ContainerUrl;

            this.Setup().Wait();
        }



        private async Task Setup()
        {
            string configurationSettings = this.connectionString;

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(configurationSettings);

            cloudBlobStorage = cloudStorageAccount.CreateCloudBlobClient();

            //Verificando se o container de Foto de Profile do Usuário está criado
            CloudBlobContainer container = cloudBlobStorage.GetContainerReference("images");

            if (await container.CreateIfNotExistsAsync())
            {
                await container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            }

            //Criando as referencias para os diretorios
            imagesDirectory = container.GetDirectoryReference(".");

        }

        public async Task<String> SaveToStorage(AzureCloudImageDirectoryStorageEnum type, byte[] buffer, string fileName)
        {
            CloudBlockBlob blob = null;

            blob = imagesDirectory.GetDirectoryReference(type.ToString().ToLower()).GetBlockBlobReference(fileName);
            

            using (Stream stream = new MemoryStream(buffer))
            {
               await blob.UploadFromStreamAsync(stream);
            }

             return $"{this.containerUrl}/images/{type.ToString().ToLower()}/{fileName}";
        }

        public async Task<byte[]> GetFromStorage(AzureCloudImageDirectoryStorageEnum type, string fileName)
        {
            byte[] file;
            CloudBlockBlob blob = null;

            blob = imagesDirectory.GetDirectoryReference(type.ToString().ToLower()).GetBlockBlobReference(fileName);

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await blob.DownloadToStreamAsync(memoryStream);
                    file = memoryStream.ToArray();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            return file;
        }
      
    }
}
