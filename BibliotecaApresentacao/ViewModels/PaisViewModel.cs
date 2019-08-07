using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class PaisViewModel
    {
        [Key]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "Nome do País é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string NomePais { get; set; }

        public virtual IEnumerable<EstadoViewModel> Estados { get; set; }
    }
}