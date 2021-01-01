using System;
using System.ComponentModel.DataAnnotations;

namespace CodersAcademyBootcamp.API.ViewModel.Albums.Request
{
    public class MusicRequest
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
