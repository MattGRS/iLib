using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Usuario
    {
        //Pessoa recebe Usuário ou o inverso?
        //Fazer uma classe validação de Login e Senha (Credenciais de Acesso)
        public string Login { get; internal set; }
        public string Senha { get; internal set; }
    }
}
