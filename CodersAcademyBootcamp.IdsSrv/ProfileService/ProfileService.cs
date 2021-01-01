using CodersAcademyBootcamp.IdsSrv.Context;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository userRepository;
        public ProfileService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userRepository.FindById(new Guid(sub));

            var claims = new List<Claim>
            {
                new Claim("iss", "CodersAcademyBootcamp"),
                new Claim("name", user.Name.ToString()),
                new Claim("email", user.Email),
                new Claim("role", "coders-academy-user"),
            };

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userRepository.FindById(new Guid(sub));

            context.IsActive = user != null;
        }
    }
}
