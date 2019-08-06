using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class AssuntoViewModel
    {
        [Key]
        public int AssuntoId { get; set; }
        [Required(ErrorMessage = "Nome do Assunto é obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        public string AssuntoObra { get; set; }
        public virtual IEnumerable<LivroViewModel> Livros { get; set; }
    }
}