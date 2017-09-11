using System.ComponentModel.DataAnnotations;

namespace PSuporte.Domain.Models.Enuns
{
    public enum TipoCurso
    {
        [Display(Name = "Ciência da comptação")]
        CienciaComputacao = 1,

        [Display(Name = "Engenharia de computação")]
        EngenhariaComputacao = 2
    }
}