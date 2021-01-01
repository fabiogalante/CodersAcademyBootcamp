using CodersAcademyBootcamp.API.ViewModel.Account.Request;
using CodersAcademyBootcamp.Application.Account.Dto.ChangePassword;
using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword;
using Hyperion.ViewModel.Account.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.ViewModel.Account.Profile
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountRequest, CreateAccountInputDto>();
            CreateMap<CreateAccountOutputDto, CreateAccountResponse>();

            CreateMap<ForgetPasswordRequest, ForgetPasswordInputDto>();

            CreateMap<ChangePasswordRequest, ChangePasswordInputDto>()
                .ForMember(x => x.NewPassword, m => m.MapFrom(f => f.Password));
        }
    }
}
