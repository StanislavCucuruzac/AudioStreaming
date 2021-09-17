using AudioStreaming.Common.Dtos.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Interfaces
{
    public interface IArtistService
    {
        Task<ArtistDto> GetArtist(int id);
        Task<IEnumerable<ArtistListDto>> GetAllArtists();
        Task<ArtistDto> AddArtist(ArtistForUpdateDto artistForUpdateDto);
        Task UpdateArtist(int id, ArtistForUpdateDto artistForUpdateDto);
        Task DeleteArtist(int id);
    }
}
