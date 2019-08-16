using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        public string CEP { get; set; } 

        [Required(ErrorMessage = "Campo Logradouro é obrgiatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Bairro { get; set; }

        public int NumeroResidencial { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Município é obrigatório.")]
        public int MunicipioId { get; set; }

        public virtual MunicipioViewModel Municipio { get; set; }

        public virtual IEnumerable<PessoaViewModel> Pessoas { get; set; }
        public virtual IEnumerable<EditoraViewModel> Editoras { get; set; }
    }
}