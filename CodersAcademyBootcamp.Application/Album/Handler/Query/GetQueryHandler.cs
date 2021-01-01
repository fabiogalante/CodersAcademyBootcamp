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
    public class GetQueryHandler : IRequestHandler<GetQueryCommand, GetQueryCommandResponse>
    {
        private IAlbumService AlbumService { get; set; }

        public GetQueryHandler(IAlbumService albumService)
        {
            AlbumService = albumService;
        }

        public async Task<GetQueryCommandResponse> Handle(GetQueryCommand request, CancellationToken cancellationToken)
        {
            var result = await this.AlbumService.GetById(request.Id);

            return new GetQueryCommandResponse(result);
        }
    }
}
