using AudioStreaming.Common.Exeptions;
using AudioStreaming.Dal;
using AudioStreaming.Domain;
using AudioStreaming.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands
{
    public class UploadSongCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string SongBaseString { get; set; }

        public UploadSongCommand(int userId, string songBaseString)
        {
            UserId = userId;
            SongBaseString = songBaseString;
        }

        public class Handler : IRequestHandler<UploadSongCommand, string>
        {
            private readonly AudioStreamingDbContext _context;
            private readonly IFileManager _fileManager;

            public Handler(AudioStreamingDbContext context, IFileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }
            public async Task<string> Handle(UploadSongCommand request, CancellationToken cancellationToken)
            {
                byte[] songBytes = Convert.FromBase64String(request.SongBaseString);

                var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);
                if (user is null)
                {
                    throw new NotFoundException(" Not found");
                }

                string slug = await Nanoid.Nanoid.GenerateAsync(size: 20);

                await _context.Songs.AddAsync(new Song(request.UserId, slug), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await _fileManager.WriteAllBytes(slug + ".mp3", songBytes);

                return slug;
            }
        }
    }
}
