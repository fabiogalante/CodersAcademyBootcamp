using CodersAcademyBootcamp.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Album.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Domain.Album.Music, MusicOutputDto>()
                .ForMember(x => x.Duration, f => f.MapFrom(m => m.Duration.Formatado));
            CreateMap<Domain.Album.Album, AlbumOutputDto>()
                .ForMember(x => x.Band, f => f.MapFrom(m => m.Band.Name));

            CreateMap<MusicInputDto, Domain.Album.Music>()
                .ForPath(x => x.Duration.Valor, f => f.MapFrom(m => m.Duration));
            CreateMap<AlbumInputDto, Domain.Album.Album>()
                .ForPath(x => x.Band.Name, f => f.MapFrom(m => m.Band));
        }

    }
}
