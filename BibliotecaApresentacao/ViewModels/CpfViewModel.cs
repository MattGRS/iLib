using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class CpfViewModel
    {
        [Required(ErrorMessage = "Campo CPF é obrigatório.")]
        [Key]
        public string Cpf { get; set; }
    }
}