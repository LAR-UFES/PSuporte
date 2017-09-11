using PSuporte.Domain.Data;
using PSuporte.Domain.Models.Enuns;
using System;

namespace PSuporte.Domain.Models
{
    public class ProcessoSeletivo : BaseEntity
    {
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Situacao Situacao { get; set; }
    }
}