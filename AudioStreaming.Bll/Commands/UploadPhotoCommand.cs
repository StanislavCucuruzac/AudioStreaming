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
    public class UploadPhotoCommand : IRequest<string>
    {
        public int ArtistId { get; set; }
        public string ImageBaseString { get; set; }

        public UploadPhotoCommand(int artistId, string imageBaseString)
        {
            ArtistId = artistId;
            ImageBaseString = imageBaseString;
        }

        public class Handler : IRequestHandler<UploadPhotoCommand, string>
        {
            private readonly AudioStreamingDbContext _context;
            private readonly IFileManager _fileManager;

            public Handler(AudioStreamingDbContext context, IFileManager fileManager)
            {
                _context = context;
                _fileManager = fileManager;
            }
            public async Task<string> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
            {
                byte[] imagesBytes = Convert.FromBase64String(request.ImageBaseString);

                var artist = await _context.Artists.FindAsync(new object[] { request.ArtistId }, cancellationToken);
                if(artist is null)
                {
                    throw new NotFoundException(" Not found");
                }

                string slug = await Nanoid.Nanoid.GenerateAsync(size: 20);

                await _context.Photos.AddAsync(new Photo(request.ArtistId, slug), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await _fileManager.WriteAllBytes(slug + ".jpg", imagesBytes);

                return slug;
            }
        }
    }
}
