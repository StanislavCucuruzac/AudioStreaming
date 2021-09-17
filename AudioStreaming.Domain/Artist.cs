using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
   public class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Style { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int SongId { get;  set; }
        public virtual List<Song> Songs { get; set; }
    }
}
