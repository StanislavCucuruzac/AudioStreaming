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
     public class GetPhotoBaseStringBySlugHandler : IRequestHandler<GetPhotoBaseStringBySlugQuery, string>
    {
        private readonly IFileManager _fileManager;

        public GetPhotoBaseStringBySlugHandler(IFileManager fileManager)
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
