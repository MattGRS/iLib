using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class LocalizacaoViewModel
    {
        [Key]
        public int LocalizacaoId { get; set; }
        [Required(ErrorMessage = "Campo Localização é obrigatório.")] 
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string LocalizacaoObra { get; set; }
        public virtual IEnumerable<LivroViewModel> Livros { get; set; }
    }
}