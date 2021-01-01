using CodersAcademyBootcamp.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Query
{
    public class GetQueryCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetQueryCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
