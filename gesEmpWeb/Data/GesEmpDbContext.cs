using gesEmpWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace gesEmpWeb.Data
{
    public class GesEmpDbContext : DbContext
    {
        public DbSet<Departement> Departements { get; set; }=null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>()
                .ToTable("Departements");
            modelBuilder.Entity<Departement>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Departement>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=gesEmpWebDb;Username=postgres;Password=Mouhamed-1234");
        }
    }
}