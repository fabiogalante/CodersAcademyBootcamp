
using CodersAcademyBootcamp.API.ViewModel.Albums.Request;
using CodersAcademyBootcamp.API.ViewModel.Albums.Response;
using CodersAcademyBootcamp.Application.Album.Dto;

namespace CodersAcademyBootcamp.API.ViewModel.Albums.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<MusicOutputDto, MusicResponse>();
            CreateMap<AlbumOutputDto, AlbumResponse>();

            CreateMap<MusicRequest, MusicInputDto>();
            CreateMap<AlbumRequest, AlbumInputDto>();
        }
    }
}
