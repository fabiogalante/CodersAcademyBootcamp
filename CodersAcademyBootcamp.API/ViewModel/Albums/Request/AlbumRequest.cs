using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CodersAcademyBootcamp.API.ViewModel.Albums.Request
{
    public class AlbumRequest : IValidatableObject
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Band { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public String Backdrop { get; set; }

        [Required]
        public List<MusicRequest> Musics { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            //VALIDA SE A MUSICA NAO É NULA
            if (this.Musics == null)
                yield return new ValidationResult("Album must contain at least one music");

            //VALIDA SE O OBJETO MUSICA TEM PELO MENOS UM ITEM
            if (this.Musics.Any() == false)
                yield return new ValidationResult("Album must contain at least one music");

            //VALIDA ITEM A ITEM DO OBJETO MUSICA
            foreach (var item in this.Musics)
            {
                if (Validator.TryValidateObject(item, new ValidationContext(item), result) == false)
                    yield return result.First();
            }
        }
    }
}
