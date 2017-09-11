using System;
using System.Collections.Generic;

namespace PSuporte.Domain.Models
{
    public class JsonResponse
    {
        public object Objeto { get; set; }
        public bool BloquearAvanco { get; set; }
        public bool Sucesso { get; set; }
        public List<string> Mensagens { get; set; }
        public List<string> Campos { get; set; }

        public JsonResponse()
        {
            Mensagens = new List<string>();
            Campos = new List<string>();
            Sucesso = false;
        }
    }
}