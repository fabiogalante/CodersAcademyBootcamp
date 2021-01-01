using CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword;
using CodersAcademyBootcamp.Application.Account.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Handler
{
    public class ForgetPasswordHandler : AsyncRequestHandler<ForgetPasswordInputDto>
    {
        private IAccountService AccountService { get; set; }

        public ForgetPasswordHandler(IAccountService accountService)
        {
            this.AccountService = accountService ?? throw new ArgumentNullException();
        }

        protected async override Task Handle(ForgetPasswordInputDto request, CancellationToken cancellationToken)
        {
            await this.AccountService.ForgetPassword(request);
        }
    }
}
