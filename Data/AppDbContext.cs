using HomeBiuld.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Numerics;

namespace HomeBiuld.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public virtual DbSet<Room>Rooms { get; set; }
        public virtual DbSet<Bad>Bads { get; set; }
        public virtual DbSet<Tv>Tvs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Bad>(r =>  r.HasMany(b=>b.Rooms).WithOne(ro=>ro.Bad).HasForeignKey(k=>k.id));
            modelBuilder.Entity<Tv>(r =>  r.HasOne(b=>b.room).WithOne(ro=>ro.Tv).HasForeignKey<Room>(k=>k.id));
   
        }



    }

  
}
