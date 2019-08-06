using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class MunicipioViewModel
    {
        [Key]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Nome do Município é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres.")]
        public string NomeMunicipio { get; internal set; }

        [Required(ErrorMessage = "Campo Estado é obrigatório.")]
        public virtual EstadoViewModel Estado { get; internal set; } //FK de Estado

        public virtual IEnumerable<EnderecoViewModel> Enderecos { get; internal set; }
    }
}