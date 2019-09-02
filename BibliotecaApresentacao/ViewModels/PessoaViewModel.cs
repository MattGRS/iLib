using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Nome da Pessoa é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório.")]
        [CPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
        
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório."),]
        public DateTime DataDeNascimento { get; set; }
        
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo Endereço é obrgiatório.")]
        public int EnderecoId { get; set; }

        public string Profissao { get; set; }

        public string Telefone { get; set; }

        //[Required(ErrorMessage = "Campo E-mail é obrigatório.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "É necessário ter um Login de acesso.")]
        public int DadosLoginId { get; set; }

        public virtual EnderecoViewModel Endereco { get; set; }

        public virtual DadosLoginViewModel Login { get; set; }

        public virtual IEnumerable<EmprestimoViewModel> Emprestimo { get; set; }
    }
}