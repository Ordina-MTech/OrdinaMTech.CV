using Microsoft.EntityFrameworkCore;
using SopraSteriaMTech.Cv.Data.Models;

namespace SopraSteriaMTech.Cv.Data;

public class CvContext(DbContextOptions<CvContext> options) : DbContext(options)
{
    public DbSet<Models.Cv> Cvs { get; set; }
    public DbSet<Ervaring> Werkervaring { get; set; }
    public DbSet<Opleiding> Opleidingen { get; set; }
    public DbSet<Cursus> Cursussen { get; set; }
    public DbSet<Kennis> Kennis { get; set; }
    public DbSet<Taal> Talen { get; set; }
    public DbSet<Personalia> Personalia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Cv>().ToTable("Cv");
        modelBuilder.Entity<Ervaring>().ToTable("Werkervaring");
        modelBuilder.Entity<Opleiding>().ToTable("Opleiding");
        modelBuilder.Entity<Cursus>().ToTable("Cursus");
        modelBuilder.Entity<Kennis>().ToTable("Kennis");
        modelBuilder.Entity<Taal>().ToTable("Taal");
        modelBuilder.Entity<Personalia>().ToTable("Personalia");
    }
}