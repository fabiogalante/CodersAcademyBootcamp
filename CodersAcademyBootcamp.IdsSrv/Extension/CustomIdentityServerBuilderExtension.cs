using CodersAcademyBootcamp.IdsSrv.Context;
using CodersAcademyBootcamp.IdsSrv.GrantType;
using CodersAcademyBootcamp.IdsSrv.ProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.AddProfileService<ProfileService>();
            builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}

