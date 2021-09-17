using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
