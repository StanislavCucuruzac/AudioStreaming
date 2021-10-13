using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos.Artists
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Style { get; set; }       
    }
}
