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
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Necessário o preenchimento do campo Login.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Necessário o preenchimento do campo Senha")]
        public string Senha { get; set; }
    }
}