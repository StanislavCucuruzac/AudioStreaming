using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain.Auth
{
   public class User : IdentityUser<int>
    {
        public int PlaylistId { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
    }
}
