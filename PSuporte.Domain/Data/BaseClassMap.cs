using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSuporte.Domain.Data
{
    public class BaseClassMap<T> where T : BaseEntity
    {
        public BaseClassMap(EntityTypeBuilder<T> entityBuilder)
        {
            entityBuilder.Property(x => x.CriadoPor).HasColumnName("ID_CRIADO_POR").IsRequired();
            entityBuilder.Property(x => x.CriadoEm).HasColumnName("DT_CRIADO_EM").IsRequired();
            entityBuilder.Property(x => x.AtualizadoPor).HasColumnName("ID_ATUALIZADO_POR").IsRequired();
            entityBuilder.Property(x => x.AtualizadoEm).HasColumnName("DT_ATUALIZADO_EM").IsRequired();
        }
    }
}
