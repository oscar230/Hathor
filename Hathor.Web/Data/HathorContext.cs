using Hathor.Web.Models;
using Hathor.Web.Models.Rekordbox;
using Microsoft.EntityFrameworkCore;

namespace Hathor.Web.Data
{
    public class HathorContext : DbContext
    {
        public HathorContext(DbContextOptions<HathorContext> options) : base(options)
        {
        }

        //public DbSet<Album> Albums => Set<Album>();
        //public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Genre> Genres => Set<Genre>();
        //public DbSet<Label> Labels => Set<Label>();
        //public DbSet<Playlist> Playlists => Set<Playlist>();
        //public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Library> Libraries => Set<Library>();
    }
}
