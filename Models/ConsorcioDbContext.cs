using Microsoft.EntityFrameworkCore;
using Administracion_Consorcio_PW3.Models.Entidades;

namespace Administracion_Consorcio_PW3.Models
{
    public class ConsorcioDbContext : DbContext
    {
        public ConsorcioDbContext(DbContextOptions<ConsorcioDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Consorcio> Consorcios { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<Gasto> Gastos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evitar cascadas múltiples en Unidad
            modelBuilder.Entity<Unidad>()
                .HasOne(u => u.UsuarioCreador)
                .WithMany()
                .HasForeignKey(u => u.IdUsuarioCreador)
                .OnDelete(DeleteBehavior.NoAction);

            // Evitar cascadas múltiples en Gasto
            modelBuilder.Entity<Gasto>()
                .HasOne(g => g.UsuarioCreador)
                .WithMany()
                .HasForeignKey(g => g.IdUsuarioCreador)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gasto>()
                .HasOne(g => g.Consorcio)
                .WithMany(c => c.Gastos)
                .HasForeignKey(g => g.IdConsorcio)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}