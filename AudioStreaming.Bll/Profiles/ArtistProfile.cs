using AudioStreaming.Common.Dtos.Artists;
using AudioStreaming.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistDto>();
                    
            CreateMap<ArtistForUpdateDto, Artist>();
            CreateMap<Artist, ArtistListDto>();
               // .ForMember(x => x.Artist, y => y.MapFrom(z => z.Artist.Name));
        }
    }
}
