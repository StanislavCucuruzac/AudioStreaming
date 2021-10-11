using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class AddSongToPlaylistCommand : IRequest<Unit>
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }

        public AddSongToPlaylistCommand(int songId, int playlistId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }

        public class Handler : IRequestHandler<AddSongToPlaylistCommand, Unit>
        {
            private readonly AudioStreamingDbContext _context;

            public Handler(AudioStreamingDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(AddSongToPlaylistCommand request, CancellationToken cancellationToken)
            {
                var playlist = await _context.Playlists.FindAsync(new object[] { request.PlaylistId }, cancellationToken);

                if(playlist is null)
                {
                    throw new NotFoundException("Not found Exeption");
                }

                
                var song = await _context.Songs.FindAsync(new object[] { request.SongId }, cancellationToken);

                if (song is null) {
                    throw new NotFoundException("Not Found");
                }

                var songPlaylist = await _context.PlaylistSongs.FirstOrDefaultAsync(songPlaylist =>
                songPlaylist.SongId == request.SongId && songPlaylist.PlaylistId == request.PlaylistId, cancellationToken);

                if(songPlaylist is not null)
                {
                    throw new BadRequestException();
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
