using AudioStreaming.Common.Dtos;
using AudioStreaming.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(x => x.ArtistId, y => y.MapFrom(z => z.Artist.Id));
            CreateMap<SongForUpdateDto, Song>();
            CreateMap<Song, SongListDto>()
                .ForMember(x => x.Artist, y => y.MapFrom(z => z.Artist.Name));
        }
    }
}
