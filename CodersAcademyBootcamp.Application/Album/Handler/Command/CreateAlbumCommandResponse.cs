using CodersAcademyBootcamp.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Command
{
    public class CreateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public CreateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
