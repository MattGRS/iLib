using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Título é um campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Titulo { get;  set; }

        [Required(ErrorMessage = "Autor é um campo obrigatório.")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Editora é um campo obrigatório.")]
        public int EditoraId { get; set; }


        [Required(ErrorMessage = "Assunto é um campo obrigatório")]
        public int AssuntoId { get; set; }


        [Required(ErrorMessage = "Classificação é um campo obrigatório.")]
        public int ClassificacaoId { get; set; }


        [Required(ErrorMessage = "Localização é um campo obrigatório.")]
        public int LocalizacaoId { get; set; }

        public virtual EditoraViewModel Editora { get; set; }

        public virtual AssuntoViewModel Assunto { get; set; }

        public virtual ClassificacaoViewModel Classificacao { get; set; }

        public virtual AutorViewModel Autor { get; set; }

        public virtual LocalizacaoViewModel Localizacao { get; set; }

        public virtual IEnumerable<ExemplarLivroViewModel> Exemplares { get;  set; }
    }
}