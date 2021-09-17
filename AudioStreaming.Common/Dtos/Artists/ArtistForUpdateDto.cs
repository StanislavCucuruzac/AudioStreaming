using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos.Artists
{
    public class ArtistForUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }
        public string Country { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public int SongId { get; set; }
    }
}
