using AudioStreaming.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Queries.Photo
{
    public class GetPhotoBySlugQuery : IRequest<byte[]>
    {
        public string PhotoSlug { get; set; }

        public GetPhotoBySlugQuery(string photoPath)
        {
            PhotoSlug= photoPath;
        }

        public class Handler : IRequestHandler<GetPhotoBySlugQuery, byte[]>
        {
            private readonly IFileManager _fileManager;

            public Handler(IFileManager fileManager)
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
}
