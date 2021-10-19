using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class Song : BaseEntity
    {
        public Song(int artistId, string slug, string name)
        {
            ArtistId = artistId;
            Slug = slug;
            Name = name;
        }
        
        public string Name { get; set; }
        public float Duration { get; set; }
        public decimal Price { get; set; }
        public string Slug { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public ICollection<PlaylistSong> Playlists { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
