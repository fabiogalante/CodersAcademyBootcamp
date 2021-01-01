using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Dto
{
    public class AlbumInputDto 
    {

        public String Name { get; set; }

        public String Band { get; set; }

        public String Description { get; set; }

        public String Backdrop { get; set; }

        public List<MusicInputDto> Musics { get; set; }
    }

   
}
