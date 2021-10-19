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

       
    }
}
