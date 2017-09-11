using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSuporte.Domain.Data;

namespace PSuporte.Domain.Models.Maps
{
    public class UsuarioMap : BaseClassMap<Usuario>
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> entityBuilder) : base(entityBuilder)
        {
            entityBuilder.ToTable("TBL_USUARIOS");

            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Nome).HasColumnName("NM_USUARIO");
            entityBuilder.Property(u => u.NomeCompleto).HasColumnName("NM_COMPLETO");
            entityBuilder.Property(u => u.Senha).HasColumnName("DS_SENHA");
        }
    }
}