using CodersAcademyBootcamp.Domain.Account;
using CodersAcademyBootcamp.Domain.Account.Repository;
using CodersAcademyBootcamp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Repository.Repository
{
    public class UserRepository : UnitOfWork<User>, IUserRepository
    {
        public UserRepository(ContextApp context) : base(context)
        {

        }
    }
}
