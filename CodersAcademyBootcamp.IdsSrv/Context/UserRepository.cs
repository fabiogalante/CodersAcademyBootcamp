using CodersAcademyBootcamp.IdsSrv.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CodersAcademyBootcamp.IdsSrv.Context
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(IOptions<DatabaseOptions> options)
        {
            this.connectionString = options.Value.DefaultConnectionString;
        }

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(UserQuery.FindByEmailAndPassword(), new { email = email, password = password });
                return user;
            }
        }

        public async Task<User> FindById(Guid subjectId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstAsync<User>(UserQuery.FindById(), new { id = subjectId });
                return user;
            }
        }
    }
}
