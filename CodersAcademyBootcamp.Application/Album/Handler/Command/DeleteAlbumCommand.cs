using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Command
{
    public class DeleteAlbumCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
