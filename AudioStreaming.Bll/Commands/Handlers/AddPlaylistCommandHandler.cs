using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands.Handlers
{
    public class AddPlaylistCommandHandler : IRequestHandler<AddPlaylistCommand, Unit>
    {
        private readonly AudioStreamingDbContext _context;

        public AddPlaylistCommandHandler(AudioStreamingDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddPlaylistCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);

            if (user is null)
                throw new NotFoundException("User not Found");

            var playList = await _context.Playlists.FindAsync(new object[] { request.PlaylistId }, cancellationToken);

            if (playList is null)
                throw new NotFoundException("Not found");


            var userPlaylist = _context.Users.FirstOrDefault(userPlaylist => userPlaylist.PlaylistId == request.PlaylistId);
            if (userPlaylist is not null)
            {
                throw new BadRequestException();
            }

            var entity = (await _context.Playlists.AddAsync(new Playlist { UserId = request.UserId, Id = request.PlaylistId }, cancellationToken)).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

       
    }
}

