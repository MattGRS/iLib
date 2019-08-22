using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class ExemplarLivroViewModel
    {
        [Key]
        public int ExemplarLivroId { get; set; }

        [Required(ErrorMessage = "Campo Registro é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Registro { get; set; }

        public int NumeroExemplar { get; set; }

        [Required]
        public int LivroId { get; set; }

        public virtual LivroViewModel Livro { get; set; }

        public virtual IEnumerable<EmprestimoViewModel> Emprestimo { get; set; }
    }
}