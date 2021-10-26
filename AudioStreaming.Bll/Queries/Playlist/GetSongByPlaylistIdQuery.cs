using AudioStreaming.Common.Helpers;
using AudioStreaming.Common.Models;
using AudioStreaming.Dal;
using AudioStreaming.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Queries.Playlist
{
    public class GetSongByPlaylistIdQuery : IRequest<ICollection<SongModel>>
    {

        public int PlaylistId { get; set; }

        public GetSongByPlaylistIdQuery(int playlistId, int loadFrom = 0)
        {
            PlaylistId = playlistId;
        }
        public class Handler : IRequestHandler<GetSongByPlaylistIdQuery, ICollection<SongModel>>
        {
            private readonly AudioStreamingDbContext _context;
            private readonly IFileManager _fileManager;

            public Handler(AudioStreamingDbContext context, IFileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }

            public async Task<ICollection<SongModel>> Handle(GetSongByPlaylistIdQuery request, CancellationToken cancellationToken)
            {
                var songs = await _context.PlaylistSongs
                    .Include(prop => prop.Song)
                    .Where(prop => prop.PlaylistId == request.PlaylistId)
                    .ToListAsync();

                return songs.Select(x=> new SongModel() {Id= x.Song.Id, Slug = x.Song.Slug , Name= x.Song.Name}).ToList();
            }
                        
        }
    }
}
