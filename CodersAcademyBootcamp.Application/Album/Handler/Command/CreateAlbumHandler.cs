using CodersAcademyBootcamp.Application.Album.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Command
{
    public class CreateAlbumHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>
    {
        private IAlbumService AlbumService { get; set; }

        public CreateAlbumHandler(IAlbumService albumService)
        {
            AlbumService = albumService;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this.AlbumService.Create(request.Album);

            return new CreateAlbumCommandResponse(result);
        }
    }
}
