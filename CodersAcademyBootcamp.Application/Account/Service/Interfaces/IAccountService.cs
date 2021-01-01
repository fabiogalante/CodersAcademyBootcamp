using CodersAcademyBootcamp.Application.Account.Dto.ChangePassword;
using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Service.Interfaces
{
    public interface IAccountService
    {
        Task<CreateAccountOutputDto> CreateAccount(CreateAccountInputDto request);
        Task ForgetPassword(ForgetPasswordInputDto request);
    }
}
