using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Photo { get; set; }
        public String CPF { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
