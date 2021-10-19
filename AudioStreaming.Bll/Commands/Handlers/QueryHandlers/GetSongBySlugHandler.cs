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
    public class GetSongBySlugHandler : IRequestHandler<GetSongBySlugQuery, byte[]>
    {
        private readonly IFileManager _fileManager;

        public GetSongBySlugHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<byte[]> Handle(GetSongBySlugQuery request, CancellationToken cancellationToken)
        {
            var songBytes = await _fileManager.ReadAllBytes(request.SongSlug + ".jpg");

            return songBytes;
        }
               
    }
}

