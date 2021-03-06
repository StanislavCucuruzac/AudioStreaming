using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Common.Dtos
{
   public class SongListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public string Slug { get;  set; }
    }
}
