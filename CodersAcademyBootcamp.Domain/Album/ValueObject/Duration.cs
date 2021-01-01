using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Domain.Album.ValueObject
{
    public class Duration
    {
        public Duration()
        {

        }

        public Duration(decimal valor)
        {
            this.Valor = valor;
        }

        public Decimal Valor { get; set; }
        public string Formatado => ValorFormatado(this.Valor);

        private string ValorFormatado(decimal valor)
        {
            var hours = Math.Floor(this.Valor/ 3600);
            var duration = this.Valor % 3600;

            var minutes = Math.Floor(duration / 60);
            var seconds = duration % 60;

            if (hours > 0)
            {
                return $"{hours.ToString().PadLeft(2, '0')} Hrs {minutes.ToString().PadLeft(2, '0')} Min  {seconds.ToString().PadLeft(2, '0')}";
            }

            return $"{minutes.ToString().PadLeft(2, '0')} Min  {seconds.ToString().PadLeft(2, '0')}";
        }
    }
}
