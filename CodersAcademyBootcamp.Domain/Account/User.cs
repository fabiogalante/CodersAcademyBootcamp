using CodersAcademyBootcamp.Crosscutting.Entity;
using CodersAcademyBootcamp.Crosscutting.Proxy;
using CodersAcademyBootcamp.Crosscutting.Utils.SecurityUtils;
using CodersAcademyBootcamp.Domain.Account.Aggregate.ValueObject;
using CodersAcademyBootcamp.Domain.Account.Enumeration;
using CodersAcademyBootcamp.Domain.Account.Rules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Domain.Account
{
    public class User : Entity<Guid>, IDomain<User>
    {


        public String Name { get; set; }
        public Email Email { get; set; }
        public String Password { get; set; }
        public String Photo { get; set; }
        public CPF CPF { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Status Status { get; set; }

        public void ApplyPassword()
        {
            this.Password = SecurityUtils.HashSHA1(this.Password);
        }

        public void ChangePassword(string password)
        {
            this.Password = SecurityUtils.HashSHA1(password);
        }

        public void Validate()
        {
            var validator = new UserValidator();

            validator.ValidateAndThrow(this);

        }

        public void ApplyStatus(Status status)
        {
            this.Status = status;
        }
    }
}
