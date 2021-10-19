using AudioStreaming.Bll.Queries.Photo;
using AudioStreaming.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Commands.Handlers.QueryHandlers
{
    public class GetPhotoBySlugHandler : IRequestHandler<GetPhotoBySlugQuery, byte[]>
    {
        private readonly IFileManager _fileManager;

        public GetPhotoBySlugHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<byte[]> Handle(GetPhotoBySlugQuery request, CancellationToken cancellationToken)
        {
            var imageBytes = await _fileManager.ReadAllBytes(request.PhotoSlug + ".jpg");

            return imageBytes;
        }
              
    }
}
