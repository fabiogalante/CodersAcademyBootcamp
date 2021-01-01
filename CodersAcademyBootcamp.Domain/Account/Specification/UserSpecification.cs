using CodersAcademyBootcamp.Crosscutting.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Domain.Account.Specification
{
    public static class UserSpecification
    {

        public static ISpecification<User> GetUserByEmail(string email) =>
            Specification<User>.CreateSpecification(x => x.Email.Valor == email);


        public static ISpecification<User> GetUserByCPF(string CPF) =>
            Specification<User>.CreateSpecification(x => x.CPF.Valor == CPF);





    }
}
