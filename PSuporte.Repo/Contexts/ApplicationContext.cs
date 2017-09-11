using Microsoft.EntityFrameworkCore;
using PSuporte.Domain.Models;
using PSuporte.Domain.Models.Maps;

namespace PSuporte.Repo.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CandidatoMap(modelBuilder.Entity<Candidato>());
            new ProcessoSeletivoMap(modelBuilder.Entity<ProcessoSeletivo>());
            new UsuarioMap(modelBuilder.Entity<Usuario>());
        }
    }
}