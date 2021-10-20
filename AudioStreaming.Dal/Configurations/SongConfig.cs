using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Configurations
{
    public class SongConfig : IEntityTypeConfiguration<Song>
    {
        
       public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasOne<Photo>(x=>x.Cover).WithMany().HasForeignKey(x=> x.CoverId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
