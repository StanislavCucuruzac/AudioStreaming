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

namespace AudioStreaming.Bll.Commands.Handlers
{
    public class UploadSongCommandHandler : IRequestHandler<UploadSongCommand, string>
    {
        private readonly AudioStreamingDbContext _context;
        private readonly IFileManager _fileManager;


        public UploadSongCommandHandler(AudioStreamingDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        public async Task<string> Handle(UploadSongCommand request, CancellationToken cancellationToken)
        {
            byte[] songBytes = request.GetFileData();


            string slug = await Nanoid.Nanoid.GenerateAsync(size: 20);

            await _context.Songs.AddAsync(new Song(request.ArtistId, slug, request.Name), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await _fileManager.WriteAllBytes(slug + ".mp3", songBytes);

            return slug;
        }

    }
}
