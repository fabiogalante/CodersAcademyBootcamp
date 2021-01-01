using CodersAcademyBootcamp.IdsSrv.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv.Context
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAndPassword(string email, string password);
        Task<User> FindById(Guid subjectId);

    }
}
