using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Application.Account.Profile
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountInputDto, User>()
                .ForPath(x => x.CPF.Valor, m => m.MapFrom(f => f.CPF))
                .ForPath(x => x.Email.Valor, m => m.MapFrom(f => f.Email));
            CreateMap<User, CreateAccountOutputDto>()
                .ForMember(x => x.CPF, m => m.MapFrom(f => f.CPF.Valor))
                .ForMember(x => x.Email, m => m.MapFrom(f => f.Email.Valor));

        }
    }
}
