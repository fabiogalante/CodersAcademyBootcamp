using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Dto.CreateAccount
{
    public class CreateAccountOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public string Photo { get; set; }

    }
}
