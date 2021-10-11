using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Playlists;
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
    public class PlaylistService : IPlaylistService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PlaylistService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task DeletePlaylist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaylistDto>> GetAllPlaylists()
        {
            var playlists = await _repository.GetAll<Playlist>();
            var playlistsDto = _mapper.Map<List<PlaylistDto>>(playlists);
            return playlistsDto;
        }

        public async Task<PlaylistDto> GetPlaylist(int id)
        {
            var playlist = await _repository.GetById<Playlist>(id);
            var playlistDto = _mapper.Map<PlaylistDto>(playlist);
            return playlistDto;
        }
    }
}
