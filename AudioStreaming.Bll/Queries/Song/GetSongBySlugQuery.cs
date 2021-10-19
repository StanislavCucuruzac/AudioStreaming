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
    public class GetSongBySlugQuery : IRequest<byte[]>
    {
        public string SongSlug { get; set; }

        public GetSongBySlugQuery(string songSlug)
        {
            SongSlug = songSlug;
        }

    }
}
