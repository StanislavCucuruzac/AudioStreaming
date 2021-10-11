using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Artists;
using AudioStreaming.Dal.Interfaces;
using AudioStreaming.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ArtistService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ArtistDto> AddArtist(ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = _mapper.Map<Artist>(artistForUpdateDto);
            _repository.Add(artist);
            await _repository.SaveChangesAsync();

            var artistDto = _mapper.Map<ArtistDto>(artist);
            return artistDto;
        }

        public async Task DeleteArtist(int id)
        {
            await _repository.Delete<Artist>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtists()
        {
            var artistList = await _repository.GetAll<Artist>();
            var artistDtoList = _mapper.Map<List<ArtistDto>>(artistList);
            return artistDtoList;

        }

        public async Task<ArtistDto> GetArtist(int id)
        {
            var artist = await _repository.GetByIdWithInclude<Artist>(id, artist => artist.Songs);
            var artistDto = _mapper.Map<ArtistDto>(artist);
            return artistDto;
        }

        public async Task UpdateArtist(int id, ArtistForUpdateDto artistForUpdateDto)
        {
            var artist = await _repository.GetById<Artist>(id);
            _mapper.Map(artistForUpdateDto, artist);
            await _repository.SaveChangesAsync();
        }
    }
}
