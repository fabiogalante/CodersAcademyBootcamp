using CodersAcademyBootcamp.Application.Album.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Query
{
    public class GetAllQueryCommandResponse 
    {
        public List<AlbumOutputDto> Albums { get; set; }

        public GetAllQueryCommandResponse()
        {

        }

        public GetAllQueryCommandResponse(List<AlbumOutputDto> albuns)
        {
            this.Albums = albuns;
        }

    }
}
