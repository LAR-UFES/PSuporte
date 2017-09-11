using System;
using System.Collections.Generic;
using System.Text;
using PSuporte.Domain.Data;

namespace PSuporte.Domain.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
    }
}
