using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Domain
{
    public class Photo : BaseEntity
    {        
        public string Slug { get; set; }      
       
        public Photo()
        {

        }
        public Photo(int artistPhotoId, string slug) : this()
        {
            Id = artistPhotoId;
            Slug = slug;
        }
    }
}
