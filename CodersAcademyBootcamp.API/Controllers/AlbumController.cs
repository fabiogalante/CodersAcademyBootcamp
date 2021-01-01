using AutoMapper;
using CodersAcademyBootcamp.API.ViewModel.Albums.Request;
using CodersAcademyBootcamp.API.ViewModel.Albums.Response;
using CodersAcademyBootcamp.Application.Album.Dto;

using CodersAcademyBootcamp.Application.Album.Handler.Command;
using CodersAcademyBootcamp.Application.Album.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodersAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "coders-academy-user")]
    public class AlbumController : ControllerBase
    {
        private IMediator Mediator { get; set; }
        private IMapper Mapper { get; set; }

        public AlbumController(IMapper mapper, IMediator mediator)
        {
            Mapper = mapper;
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbuns()
        {
            var query = await this.Mediator.Send(new GetAllQueryCommand());

            var result = this.Mapper.Map<List<AlbumResponse>>(query.Albums);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {

            var query = await this.Mediator.Send(new GetQueryCommand() { Id = id });

            var result = this.Mapper.Map<AlbumResponse>(query.Album);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAlbuns(AlbumRequest request)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            AlbumInputDto album = this.Mapper.Map<AlbumInputDto>(request);

            var query = await this.Mediator.Send(new CreateAlbumCommand(album));

            var result = this.Mapper.Map<AlbumResponse>(query.Album);

            return Created($"/{result.Id}", result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            var query = await this.Mediator.Send(new GetQueryCommand() { Id = id });

            var result = this.Mapper.Map<AlbumResponse>(query.Album);

            if (result == null)
                return NotFound();

            await this.Mediator.Send(new DeleteAlbumCommand() { Id = id });

            return NoContent();
        }

    }
}
