using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword
{
    public class ForgetPasswordInputDto : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
