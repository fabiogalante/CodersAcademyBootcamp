using AutoMapper;
using CodersAcademyBootcamp.Application.Album.Dto;
using CodersAcademyBootcamp.Application.Album.Service.Interfaces;
using CodersAcademyBootcamp.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumService(IMapper mapper, IAlbumRepository albumRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = this.mapper.Map<Domain.Album.Album>(dto);

            await this.albumRepository.Save(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task Delete(Guid id)
        {
            var result = await this.albumRepository.Get(id);

            await this.albumRepository.Delete(result);
        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            var result = await this.albumRepository.GetAll();

            return this.mapper.Map<List<AlbumOutputDto>>(result);
        }

        public async Task<AlbumOutputDto> GetById(Guid id)
        {
            var result = await this.albumRepository.Get(id);

            return this.mapper.Map<AlbumOutputDto>(result);
        }
    }
}
