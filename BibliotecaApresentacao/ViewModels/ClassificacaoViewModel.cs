using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class ClassificacaoViewModel
    {
        [Key]
        public int ClassificacaoId { get; set; }
        [Required(ErrorMessage = "Campo Classificação é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres.")]
        public string ClassificacaoObra { get; internal set; }
        public virtual IEnumerable<LivroViewModel> Livros { get; internal set; }
    }
}