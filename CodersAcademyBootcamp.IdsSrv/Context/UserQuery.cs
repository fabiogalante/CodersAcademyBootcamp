using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv.Context
{
    public static class UserQuery
    {
        public static string FindById() =>
            @"SELECT Id,
                     Name,
                     Email,
                     Password,
                     Photo,
                     CPF,
                     DateOfBirth
              FROM [USER]
              WHERE ID = @id";

        public static string FindByEmailAndPassword() =>
            @"SELECT Id,
                     Name,
                     Email,
                     Password,
                     Photo,
                     CPF,
                     DateOfBirth
              FROM [USER]
              WHERE Email = @email
              AND   Password = @password
            ";
    }
}
