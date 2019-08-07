using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class DadosLoginViewModel
    {
        [Key]
        public int DadosLoginId { get; set; }
        [Required(ErrorMessage = "Necessário o preenchimento do campo Login."), MaxLength(100)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Necessário o preenchimento do campo Senha"), MaxLength(100)]
        public string Senha { get; set; }
    }
}