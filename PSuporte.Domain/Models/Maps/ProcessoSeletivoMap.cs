using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSuporte.Domain.Data;

namespace PSuporte.Domain.Models.Maps
{
    public class ProcessoSeletivoMap : BaseClassMap<ProcessoSeletivo>
    {
        public ProcessoSeletivoMap(EntityTypeBuilder<ProcessoSeletivo> entityBuilder) : base (entityBuilder)
        {
            entityBuilder.ToTable("TBL_PROCESSOS_SELETIVOS");

            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("ID_PROCESSO_SELETIVO");
            entityBuilder.Property(p => p.Situacao).HasColumnName("FL_SITUACAO");
            entityBuilder.Property(p => p.DataInicio).HasColumnName("DT_INICIO");
            entityBuilder.Property(p => p.DataFim).HasColumnName("DT_FIM");
            entityBuilder.Property(p => p.Titulo).HasColumnName("DS_TITULO");
        }
    }
}