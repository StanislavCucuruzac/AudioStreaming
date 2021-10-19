using AudioStreaming.Bll.Commands.Delete;
using AudioStreaming.Common.Exeptions;
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

namespace AudioStreaming.Bll.Commands.Handlers
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, Unit>
    {
        private readonly AudioStreamingDbContext _context;
        private readonly IFileManager _fileManager;

        public DeletePhotoCommandHandler(AudioStreamingDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var artist = await _context.Photos.FindAsync(new object[] { request.ArtistId }, cancellationToken);

            if (artist is null)
                throw new NotFoundException("Not found");

            var artistPhoto = await _context.Photos.FirstOrDefaultAsync(photo => photo.Slug == request.PhotoSlug, cancellationToken);

            if (artistPhoto is null)
                throw new NotFoundException("Not found");

            if (artistPhoto.Id != request.ArtistId)
                throw new BadRequestException();

            _context.Photos.Remove(artistPhoto);
            await _context.SaveChangesAsync(cancellationToken);
            await _fileManager.Delete(artistPhoto.Slug + ".jpg");

            return Unit.Value;
        }

    }
}
