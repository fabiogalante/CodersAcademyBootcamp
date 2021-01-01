using CodersAcademyBootcamp.Crosscutting.Utils.SecurityUtils;
using CodersAcademyBootcamp.IdsSrv.Context;
using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv.GrantType
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository userRepository;

        public ResourceOwnerPasswordValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var email = context.UserName;

            var user = await this.userRepository.FindByEmailAndPassword(email, SecurityUtils.HashSHA1(password));

            if (user is not null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
