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
   public class ContactInfoConfig : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(x => x.ContactInfoId);
            builder.HasOne(x => x.Artist)
                .WithOne(x => x.ContactInfo)
                .HasForeignKey<ContactInfo>(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
