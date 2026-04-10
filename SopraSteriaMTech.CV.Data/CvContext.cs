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
}