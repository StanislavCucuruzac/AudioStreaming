using AudioStreaming.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos.Playlists
{
    public class PlaylistForUpdateDto
    {
        [Required]        
        public string Name { get; set; }       
        public int UserId { get; set; }
      //  public List<Song> Songs { get; set; }
    }
}
