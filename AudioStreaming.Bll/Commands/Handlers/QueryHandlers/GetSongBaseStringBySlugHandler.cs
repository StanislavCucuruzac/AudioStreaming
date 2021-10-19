using AudioStreaming.Bll.Queries.Song;
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
    public class GetSongBaseStringBySlugHandler : IRequestHandler<GetSongBaseStringBySlugQuery, string>
    {
        private readonly IFileManager _fileManager;

        public GetSongBaseStringBySlugHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<string> Handle(GetSongBaseStringBySlugQuery request, CancellationToken cancellationToken)
        {
            var songBytes = await _fileManager.ReadAllBytes(request.SongSlug + ".jpg");

            var songBaseString = Convert.ToBase64String(songBytes);

            return songBaseString;
        }
                
    }
}
