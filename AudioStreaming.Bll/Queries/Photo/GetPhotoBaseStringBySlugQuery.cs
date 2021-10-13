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
    public class GetPhotoBaseStringBySlugQuery : IRequest<string>
    {
        public string PhotoSlug { get; set; }

        public GetPhotoBaseStringBySlugQuery(string slug)
        {
            PhotoSlug = slug;
        }

        public class Handler : IRequestHandler<GetPhotoBaseStringBySlugQuery, string>
        {
            private readonly IFileManager _fileManager;

            public Handler(IFileManager fileManager)
            {
                _fileManager = fileManager;
            }

            public async Task<string> Handle(GetPhotoBaseStringBySlugQuery request, CancellationToken cancellationToken)
            {
                var imageBytes = await _fileManager.ReadAllBytes(request.PhotoSlug + ".jpg");

                var photoBaseString = Convert.ToBase64String(imageBytes);

                return photoBaseString;
            }

        }
    }
}
