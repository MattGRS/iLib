using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public enum StatusExemplarLivro
    {
        [Display(Name = "Disponível")]
        Disponivel,
        [Display(Name = "Reservado")]
        Reservado,
        [Display(Name = "Indisponível")]
        Indisponivel
    }
}
