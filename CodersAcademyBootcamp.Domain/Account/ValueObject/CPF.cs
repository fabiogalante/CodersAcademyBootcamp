using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodersAcademyBootcamp.Domain.Account.Aggregate.ValueObject
{
    public class CPF
    {
        public CPF()
        {

        }

        public CPF(string valor)
        {
            this.Valor = valor?.Replace(".","").Replace("-","") ?? throw new ArgumentNullException(nameof(CPF));
        }

        public string Valor { get; set; }
        public string Formatado => ValorFormatado(this.Valor);


        #region Private Methods
        private string ValorFormatado(string valor) => Convert.ToInt64(valor).ToString(@"000\.000\.000\-00");
        #endregion
    }
}
