using AudioStreaming.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
     
        public ICollection<PlaylistSong> Songs { get; set; }
    }
}
