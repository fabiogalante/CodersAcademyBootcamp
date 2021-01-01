using CodersAcademyBootcamp.Domain.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Domain.Account.Rules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(bool validatePassword = true)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.CPF).SetValidator(new CPFValidator());

            RuleFor(x => x.Password).NotEmpty();
        }


    }
}
