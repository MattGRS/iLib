using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        public string CEP { get; internal set; } 

        [Required(ErrorMessage = "Campo Logradouro é obrgiatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Logradouro { get; internal set; }

        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Bairro { get; internal set; }

        public int NumeroResidencial { get; internal set; }

        public string Complemento { get; internal set; }

        [Required(ErrorMessage = "Campo Município é obrigatório.")]
        public virtual MunicipioViewModel Municipio { get; internal set; }

        public virtual IEnumerable<PessoaViewModel> Pessoas { get; internal set; }
        public virtual IEnumerable<EditoraViewModel> Editoras { get; internal set; }
    }
}