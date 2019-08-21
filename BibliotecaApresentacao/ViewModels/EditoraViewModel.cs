using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class EditoraViewModel
    {
        [Key]
        public int EditoraId { get; set; }

        [Required(ErrorMessage = "Nome da Editora é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string NomeEditora { get; set; }

        [Required(ErrorMessage = "Campo Endereço é obrigatório.")]
        public int EnderecoId { get; set; }

        public virtual EnderecoViewModel Endereco { get; set; } //FK de endereços

        public virtual IEnumerable<LivroViewModel> Livros { get; set; }
    }
}