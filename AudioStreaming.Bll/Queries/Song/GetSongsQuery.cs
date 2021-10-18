using AudioStreaming.Common.Dtos;
using AudioStreaming.Common.Exeptions;
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

namespace AudioStreaming.Bll.Queries.Song
{
    public class GetSongsQuery : IRequest<ICollection<SongModel>>
    {
        public int PlaylistId { get; set; }
        public int LoadFrom { get; set; }

        public GetSongsQuery(int playlistId, int loadFrom = 0)
        {
            PlaylistId = playlistId;
            LoadFrom = loadFrom;
        }

        public class Handler : IRequestHandler<GetSongsQuery, ICollection<SongModel>>
        {
            private readonly AudioStreamingDbContext _context;
            private readonly IFileManager _fileManager;

            public Handler(AudioStreamingDbContext context, IFileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }

            public async Task<ICollection<SongModel>> Handle(GetSongsQuery request, CancellationToken cancellationToken)
            {
                var songs = await _context.Songs
                    .Where(prop =>
                      prop.Id == request.PlaylistId)
                    .Skip(request.LoadFrom)
                    .Take(2)
                    .Select(prop => new SongModel() { Id = prop.Id, Slug = prop.Slug })
                    .ToListAsync();

                for(int i = 0; i < songs.Count; i++){
                    songs[i].Src = await AudioStreamContextHelper.TryGetSongBase64BySlug(songs[i].Slug, _fileManager);

                }
                return songs;
            }


        }
    }

}
