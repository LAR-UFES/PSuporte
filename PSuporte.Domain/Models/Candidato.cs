using PSuporte.Domain.Data;
using PSuporte.Domain.Models.Enuns;

namespace PSuporte.Domain.Models
{
    public class Candidato : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public TipoCurso Curso { get; set; }

        public byte[] HorarioIndividual { get; set; }

        public string Indisponibilidades { get; set; }

        public long ProcessoSeletivoId { get; set; }

        public virtual ProcessoSeletivo ProcessoSeletivo { get; set; }
    }
}