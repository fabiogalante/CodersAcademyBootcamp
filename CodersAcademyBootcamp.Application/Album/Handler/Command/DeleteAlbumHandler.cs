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
    public class DeleteAlbumHandler : AsyncRequestHandler<DeleteAlbumCommand>
    {
        private IAlbumService AlbumService { get; set; }

        public DeleteAlbumHandler(IAlbumService albumService)
        {
            AlbumService = albumService;
        }

        protected async override Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            await this.AlbumService.Delete(request.Id);
        }
    }
}
