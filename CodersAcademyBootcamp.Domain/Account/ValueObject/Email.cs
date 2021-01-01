using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodersAcademyBootcamp.Domain.Account.Aggregate.ValueObject
{
    public class Email
    {
        

        public Email()
        {

        }

        public Email(string email)
        {
            this.Valor = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Valor { get; set; }

    }
}
