using Microsoft.EntityFrameworkCore;

namespace OrdinaMTech.Cv.Data
{
    public class CvContext : DbContext
    {
        public CvContext(DbContextOptions<CvContext> options) : base(options)
        {
        }

        public DbSet<Models.Cv> Cvs { get; set; }
        public DbSet<Models.Ervaring> Werkervaring { get; set; }
        public DbSet<Models.Opleiding> Opleidingen { get; set; }
        public DbSet<Models.Cursus> Cursussen { get; set; }
        public DbSet<Models.Kennis> Kennis { get; set; }
        public DbSet<Models.Taal> Talen { get; set; }
        public DbSet<Models.Personalia> Personalia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cv>().ToTable("Cv");
            modelBuilder.Entity<Models.Ervaring>().ToTable("Werkervaring");
            modelBuilder.Entity<Models.Opleiding>().ToTable("Opleiding");
            modelBuilder.Entity<Models.Cursus>().ToTable("Cursus");
            modelBuilder.Entity<Models.Kennis>().ToTable("Kennis");
            modelBuilder.Entity<Models.Taal>().ToTable("Taal");
            modelBuilder.Entity<Models.Personalia>().ToTable("Personalia");
        }

    }
}