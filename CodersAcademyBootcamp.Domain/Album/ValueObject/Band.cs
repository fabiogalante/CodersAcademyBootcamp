using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Domain.Album.ValueObject
{
    public class Band
    {
        public Band()
        {

        }

        public Band(String name)
        {
            this.Name = name;
        }

        public String Name { get; set; }
    }
}
