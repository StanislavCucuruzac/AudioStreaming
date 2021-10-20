using AudioStreaming.Dal.Configurations;
using AudioStreaming.Dal.Constants;
using AudioStreaming.Domain;
using AudioStreaming.Domain.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal
{
    public class AudioStreamingDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AudioStreamingDbContext(DbContextOptions<AudioStreamingDbContext> options) : base(options)
        {
        }

        // public DbSet<Domain.User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ContactInfoConfig());

            ApplyIdentityMapConfiguration(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtistConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Artist>()
            //.HasOne(p => p.ArtistPhoto)
            //.WithOne(a => a.Artist)
            //.HasForeignKey<Photo>(b => b.ArtistId);


            modelBuilder.Entity<PlaylistSong>()
       .HasKey(sp => new { sp.SongId, sp.PlaylistId });
            modelBuilder.Entity<PlaylistSong>()
                .HasOne(sp => sp.Song)
                .WithMany(p => p.Playlists)
                .HasForeignKey(sp => sp.SongId);
            modelBuilder.Entity<PlaylistSong>()
                .HasOne(sp => sp.Playlist)
                .WithMany(s => s.Songs)
                .HasForeignKey(sp => sp.PlaylistId);


            modelBuilder.Entity<Song>().Property(p => p.Price).HasColumnType("decimal(18,4)");
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConstants.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
        }

    }
}
