using CodersAcademyBootcamp.Application.Album.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Handler.Query
{
    public class GetAllQueryCommand : IRequest<GetAllQueryCommandResponse>
    {
        public GetAllQueryCommand()
        {

        }

    }
}
