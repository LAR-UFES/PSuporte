using System.ComponentModel.DataAnnotations;

namespace PSuporte.Domain.Models.Enuns
{
    public enum Situacao
    {
        [Display(Name = "Em andamento")]
        EmAndamento = 1,

        [Display(Name = "Encerrado")]
        Encerrado = 2,

        [Display(Name = "Cancelado")]
        Cancelado = 3
    }
}