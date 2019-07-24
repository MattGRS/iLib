using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Usuario
    {
        //Pessoa recebe Usuário ou o inverso?
        //Fazer uma classe validação de Login e Senha (Credenciais de Acesso)
        [Required]
        public string Login { get; internal set; }
        [Required]
        public string Senha { get; internal set; }
        public Pessoa Pessoa { get; internal set; }
    }
}
