using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Contexto
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasData(new Pais(1, "País Teste"));
            modelBuilder.Entity<Estado>().HasData(new Estado(1, "Estado Teste", 1));
            modelBuilder.Entity<Municipio>().HasData(new Municipio(1, "Município Teste", 1));
            modelBuilder.Entity<Endereco>().HasData(new Endereco(1, "87080590", "Endereço Teste", "Bairro Teste", 1));
            modelBuilder.Entity<DadosLogin>().HasData(new DadosLogin(1, "adm", "adm"));
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa(1, "Pessoa Teste", "31665750227", 1, 1));
            modelBuilder.Entity<Localizacao>().HasData(new Localizacao(1, "Localização Teste"));
            modelBuilder.Entity<Editora>().HasData(new Editora(1, "Editora Teste", 1));
            modelBuilder.Entity<Classificacao>().HasData(new Classificacao(1, "Classificação Teste"));
            modelBuilder.Entity<Autor>().HasData(new Autor(1, "Autor Teste"));
            modelBuilder.Entity<Assunto>().HasData(new Assunto(1, "Assunto Teste"));
            modelBuilder.Entity<Livro>().HasData(new Livro(1, "Livro Teste", 1, 1, 1, 1, 1));
            modelBuilder.Entity<ExemplarLivro>().HasData(new ExemplarLivro(1, "123456", 1, 1));
        }
    }
}
