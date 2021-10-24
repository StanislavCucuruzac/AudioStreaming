using AudioStreaming.Common.Dtos;
using AudioStreaming.Common.PagedRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Interfaces
{
    public interface ISongService
    {
        Task<PaginatedResult<SongListDto>> GetPagedSongs(PagedRequest pagedRequest);
        Task<SongDto> GetSong(int id);
        Task<IEnumerable<SongListDto>> GetAllSongs();
        Task<SongDto> AddSong(SongForUpdateDto songForUpdateDto);
        Task UpdateSong(int id, SongForUpdateDto songForUpdateDto);
        Task DeleteSong(int id);
    }
}
