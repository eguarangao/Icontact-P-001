
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
            // Definir claves primarias
            modelBuilder.Entity<Horario>().HasKey(h => h.IdHorario);
            modelBuilder.Entity<Pelicula>().HasKey(p => p.IdPelicula);
            modelBuilder.Entity<Sala>().HasKey(s => s.IdSala);

            // Configurar relaciones
            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Sala)
                .WithMany(s => s.Horarios)
                .HasForeignKey(h => h.IdSala);

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Pelicula)
                .WithMany(p => p.Horarios)
                .HasForeignKey(h => h.IdPelicula);


            base.OnModelCreating(modelBuilder);
        }
    }
}
