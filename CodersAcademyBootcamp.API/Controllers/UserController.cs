using AutoMapper;
using CodersAcademyBootcamp.API.ViewModel.Account.Request;
using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "coders-academy-user")]
    public class UserController : ControllerBase
    {
        private IMapper Mapper { get; set; }
        private IMediator Mediator { get; set; }

        public UserController(IMapper mapper, IMediator mediator)
        {
            Mapper = mapper;
            Mediator = mediator;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult<IActionResult>(BadRequest(ModelState));

            var inputDto = this.Mapper.Map<CreateAccountInputDto>(createAccountRequest);

            var result = await this.Mediator.Send(inputDto);

            return await Task.FromResult<IActionResult>(Created(String.Empty, result));
        }

        [Route("ForgetPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest forgetPasswordRequest)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult<IActionResult>(BadRequest(ModelState));

            var inputDto = this.Mapper.Map<ForgetPasswordInputDto>(forgetPasswordRequest);

            await this.Mediator.Send(inputDto);

            return await Task.FromResult<IActionResult>(Ok());
        }

    }
}
