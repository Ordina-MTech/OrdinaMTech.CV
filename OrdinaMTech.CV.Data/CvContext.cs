using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OrdinaMTech.Cv.Data
{
    public class CvContext : DbContext
    {
        public DbSet<Models.Cv> Cvs { get; set; }

        public CvContext(DbContextOptions<CvContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Cv");
            modelBuilder.Entity<Models.Cv>().ToContainer("Cv");
        }

    }
}