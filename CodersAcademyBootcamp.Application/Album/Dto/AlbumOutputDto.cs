using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Dto
{
    public class AlbumOutputDto 
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }
        public String Backdrop { get; set; }
        public String Band { get; set; }
        public IList<MusicOutputDto> Musics { get; set; }
    }
}
