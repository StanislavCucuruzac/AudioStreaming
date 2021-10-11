using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class PlaylistSong
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }

        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
