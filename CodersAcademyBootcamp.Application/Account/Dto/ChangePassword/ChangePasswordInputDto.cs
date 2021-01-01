using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Dto.ChangePassword
{
    public class ChangePasswordInputDto : IRequest
    {
        public string Email { get; set; }

        public string NewPassword { get; set; }
    }
}
