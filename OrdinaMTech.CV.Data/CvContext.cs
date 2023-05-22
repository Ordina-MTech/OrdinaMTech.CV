using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OrdinaMTech.Cv.Data
{
    public class CvContext : DbContext
    {
        public DbSet<Models.Cv> Cvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
            "https://cosmos-cv.documents.azure.com:443/",
            "nqcNvgDGEq7CIwBo7gr6dD1mYt4uzIJnK3lsv4sJKp8cLFpV9xgLKVYPksFFqLFcaA7vryzhUNi6ACDbR2ZnrQ==",
            databaseName: "Cv");

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