using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Proxy
{
    public class ProxyUtils
    {
        public static byte[] DownloadFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    if ((httpWebReponse.StatusCode == HttpStatusCode.OK || httpWebReponse.StatusCode == HttpStatusCode.Moved
                        || httpWebReponse.StatusCode == HttpStatusCode.Redirect))
                    {
                        using (Stream stream = httpWebReponse.GetResponseStream())
                        {
                            MemoryStream ms = new MemoryStream();
                            stream.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public static String MakeRequest(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebReponse.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(stream);
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                return null;
            }

        }


    }
}
