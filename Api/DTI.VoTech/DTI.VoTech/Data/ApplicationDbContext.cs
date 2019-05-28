using DTI.VoTech.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DTI.VoTech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Techshot> Techshots { get; set; }

        public DbSet<Tema> Temas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Votacao> Votacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Techshot>(e =>
            {
                e.HasKey(c => c.TechshotId);
                e.HasOne<>().WithMany().HasForeignKey();
            });
            modelBuilder.Entity<Tema>(e => { e.HasKey(c => c.TemaId); });
            modelBuilder.Entity<Usuario>(e => { e.HasKey(c => c.UsuarioId); });
            modelBuilder.Entity<Votacao>(e => { e.HasKey(c => c.VotacaoId); });
            base.OnModelCreating(modelBuilder);
        }
    }
}