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
    public class GetPhotoBaseStringByPathQuery : IRequest<string>
    {
        public string PhotoSlug { get; set; }

        public GetPhotoBaseStringByPathQuery(string slug)
        {
            PhotoSlug = slug;
        }

        public class Handler : IRequestHandler<GetPhotoBaseStringByPathQuery, string>
        {
            private readonly IFileManager _fileManager;

            public Handler(IFileManager fileManager)
            {
                _fileManager = fileManager;
            }

            public async Task<string> Handle(GetPhotoBaseStringByPathQuery request, CancellationToken cancellationToken)
            {
                var imageBytes = await _fileManager.ReadAllBytes(request.PhotoSlug + ".jpg");

                var photoBaseString = Convert.ToBase64String(imageBytes);

                return photoBaseString;
            }

        }
    }
}
