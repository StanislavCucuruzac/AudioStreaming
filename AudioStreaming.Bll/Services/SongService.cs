using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos;
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
   public class SongService : ISongService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public SongService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SongDto> AddSong(SongForUpdateDto songForUpdateDto)
        {
            var song = _mapper.Map<Song>(songForUpdateDto);
            _repository.Add(song);
            await _repository.SaveChangesAsync();

            var songDto = _mapper.Map<SongDto>(song);
            return songDto;
            
        }

        public async Task DeleteSong(int id)
        {
            await _repository.Delete<Song>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SongListDto>> GetAllSongs()
        {
            var songList = await _repository.GetAll<Song>();
            var songDtoList = _mapper.Map<List<SongListDto>>(songList);
            return songDtoList;
        }

        public async Task<SongDto> GetSong(int id)
        {
            var song = await _repository.GetByIdWithInclude<Song>(id, song => song.Artist);
            var songDto = _mapper.Map<SongDto>(song);
            return songDto;
        }

        public async Task UpdateSong(int id, SongForUpdateDto songForUpdateDto)
        {
            var song = await _repository.GetById<Song>(id);
            _mapper.Map(songForUpdateDto, song);
            await _repository.SaveChangesAsync();
        }
    }
}
