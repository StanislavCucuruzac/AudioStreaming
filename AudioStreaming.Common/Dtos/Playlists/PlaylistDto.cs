using AudioStreaming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos.Playlists
{
    public class PlaylistDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<Song> Songs { get; set; }
    }
}
