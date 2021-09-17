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
    //public class UserConfig : IEntityTypeConfiguration<User>
    //{      
    //    public void Configure(EntityTypeBuilder<User> builder)
    //    {
    //        builder.Property(u => u.UserName)
    //              .HasMaxLength(255);

    //        builder.Property(u => u.Email)
    //            .HasMaxLength(255);

    //        builder.HasMany(p => p.Playlists)
    //            .WithOne(u => u.User)
    //            .HasForeignKey(u => u.UserId);

    //        builder.Property(x => x.RowVersion)
    //            .IsRowVersion();
    //    }
    //}
}
