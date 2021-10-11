using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos
{
    public class SongForUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Range(1,99)]
        public float Duration { get; set; }
        
        public decimal Price { get; set; }
        [Required]
        public int ArtistId { get; set; }
    }
}
