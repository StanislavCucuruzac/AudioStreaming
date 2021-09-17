using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public float Duration { get; set; }
        public decimal Price { get; set; }
        //  public byte[] Data { get; set; }
        public int? FileSize { get; set; }
        public string FilePath { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
