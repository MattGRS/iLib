using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Exemplar
    {
        public int ExemplarId { get; set; }
        [Required, StringLength(15)]
        public string Registro { get; internal set; }
        public int NumeroExemplar { get; internal set; }
        public Livro Livro { get; internal set; } //FK de Livro
    }
}
