using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSuporte.Domain.Data;

namespace PSuporte.Domain.Models.Maps
{
    public class CandidatoMap : BaseClassMap<Candidato>
    {
        public CandidatoMap(EntityTypeBuilder<Candidato> entityBuilder) : base(entityBuilder)
        {
            entityBuilder.ToTable("TBL_CANDIDATOS");

            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.Id).HasColumnName("ID_CANDIDATO").IsRequired();
            entityBuilder.Property(c => c.Nome).HasColumnName("NM_CANDIDATO").IsRequired();
            entityBuilder.Property(c => c.Curso).HasColumnName("TP_CURSO").IsRequired();
            entityBuilder.Property(c => c.HorarioIndividual).HasColumnName("DS_HORARIO_INDIVIDUAL");
            entityBuilder.Property(c => c.Indisponibilidades).HasColumnName("DS_INDISPONIBILIDADES");
            entityBuilder.Property(c => c.Email).HasColumnName("DS_EMAIL").IsRequired();
            entityBuilder.Property(c => c.ProcessoSeletivoId).HasColumnName("ID_PROCESSO_SELETIVO").IsRequired();
            entityBuilder.HasOne(c => c.ProcessoSeletivo).WithMany().HasForeignKey(c => c.ProcessoSeletivoId).HasConstraintName("FK_TBL_entityBuilder_X_TBL_PROCESSOS_SELETIVOS");
        }
    }
}