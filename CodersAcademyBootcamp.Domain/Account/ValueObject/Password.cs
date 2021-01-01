using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Domain.Account.Aggregate.ValueObject
{
    public class Password
    {
        public Password()
        {

        }

        public Password(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }

        public string Valor { get; set; }
    }
}
