using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Nome do Estado é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string NomeEstado { get; set; }

        [Required(ErrorMessage = "Campo Pais é obrigatório.")]
        public virtual PaisViewModel Pais { get; set; }

        public virtual IEnumerable<MunicipioViewModel> Municipios { get; internal set; }
    }
}