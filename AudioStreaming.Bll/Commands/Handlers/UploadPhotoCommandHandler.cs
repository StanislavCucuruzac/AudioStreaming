using AudioStreaming.Dal;
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
    public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, string>
    {
        private readonly AudioStreamingDbContext _context;
        private readonly IFileManager _fileManager;


        public UploadPhotoCommandHandler(AudioStreamingDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        public async Task<string> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            byte[] imagesBytes = request.GetFileData();


            string slug = await Nanoid.Nanoid.GenerateAsync(size: 20);

            await _context.SaveChangesAsync(cancellationToken);
            await _fileManager.WriteAllBytes(slug + ".jpg", imagesBytes);

            return slug;
        }

    }
}
