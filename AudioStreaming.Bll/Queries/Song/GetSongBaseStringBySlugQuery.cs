using AudioStreaming.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioStreaming.Bll.Queries.Song
{
    public class GetSongBaseStringBySlugQuery : IRequest<string>
    {
        public string SongSlug { get; set; }

        public GetSongBaseStringBySlugQuery(string songSlug)
        {
            SongSlug = songSlug;
        }

        public class Handler : IRequestHandler<GetSongBaseStringBySlugQuery, string>
        {
            private readonly IFileManager _fileManager;

            public Handler(IFileManager fileManager)
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
}
