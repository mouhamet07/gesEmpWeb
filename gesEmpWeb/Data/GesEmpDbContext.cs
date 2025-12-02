using gesEmpWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace gesEmpWeb.Data
{
    public class GesEmpDbContext : DbContext
    {
        public DbSet<Departement> Departements { get; set; }=null!;
        public DbSet<Employe> Employes { get; set; }=null!;

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

            modelBuilder.Entity<Employe>()
                .ToTable("Employes");
            modelBuilder.Entity<Employe>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Employe>()
                .Property(d => d.NomComplet)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Employe>()
                .Property(d => d.Numero)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Employe>()
                .Property(d => d.Telephone)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Employe>()
                .Property(d => d.DepartementId)
                .IsRequired();

            // Configuration de la relation Foreign Key
            modelBuilder.Entity<Employe>()
                .HasOne(e => e.DepartementEmp)
                .WithMany()
                .HasForeignKey(e => e.DepartementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=gesEmpWebDb;Username=postgres;Password=Mouhamed-1234");
        }
    }
}