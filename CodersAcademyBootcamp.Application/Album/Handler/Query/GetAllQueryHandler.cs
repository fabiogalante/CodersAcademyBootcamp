using CodersAcademyBootcamp.Application.Album.Dto;

using CodersAcademyBootcamp.Application.Album.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Query
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQueryCommand, GetAllQueryCommandResponse>
    {
        private IAlbumService AlbumService { get; set; }

        public GetAllQueryHandler(IAlbumService albumService)
        {
            AlbumService = albumService;
        }

        public async Task<GetAllQueryCommandResponse> Handle(GetAllQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await this.AlbumService.GetAll();

            return new GetAllQueryCommandResponse(result);
        }
    }
}
