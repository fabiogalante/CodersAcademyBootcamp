using CodersAcademyBootcamp.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Service.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumOutputDto>> GetAll();
        Task<AlbumOutputDto> GetById(Guid id);
        Task<AlbumOutputDto> Create(AlbumInputDto album);
        Task Delete(Guid id);
    }
}
