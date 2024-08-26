
using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Sala)
                .WithMany()
                .HasForeignKey(h => h.IdSala);

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Pelicula)
                .WithMany()
                .HasForeignKey(h => h.IdPelicula);

            base.OnModelCreating(modelBuilder);
        }
    }
}
