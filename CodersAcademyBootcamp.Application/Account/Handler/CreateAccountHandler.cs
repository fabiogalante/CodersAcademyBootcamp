using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Application.Account.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Handler
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountInputDto, CreateAccountOutputDto>
    {
        private IAccountService AccountService { get; set; }

        public CreateAccountHandler(IAccountService accountService)
        {
            this.AccountService = accountService ?? throw new ArgumentNullException();
        }

        public async Task<CreateAccountOutputDto> Handle(CreateAccountInputDto request, CancellationToken cancellationToken)
        {
            return await this.AccountService.CreateAccount(request);
        }
    }
}
