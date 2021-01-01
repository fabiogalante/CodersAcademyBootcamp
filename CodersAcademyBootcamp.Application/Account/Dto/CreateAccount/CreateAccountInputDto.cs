using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Dto.CreateAccount
{
    public class CreateAccountInputDto : IRequest<CreateAccountOutputDto>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
