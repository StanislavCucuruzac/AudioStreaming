using AudioStreaming.Common.Dtos.Playlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Interfaces
{
    public interface IPlaylistService
    {
        Task<PlaylistDto> AddPlaylist(PlaylistForUpdateDto playlistFroUpdateDto);
        Task<IEnumerable<PlaylistListDto>> GetAllPlaylists();
        Task<PlaylistDto> GetPlaylist(int id);
        Task DeletePlaylist(int id);
    }
}
