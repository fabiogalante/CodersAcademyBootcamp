using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.ViewModel.Albums.Response
{
    public class AlbumResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }
        public String Backdrop { get; set; }
        public String Band { get; set; }
        public IList<MusicResponse> Musics { get; set; }
    }
}
