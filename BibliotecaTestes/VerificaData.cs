using BibliotecaDominio.Entidades;
using System;
using Xunit;

namespace BibliotecaTestes
{
    public class VerificaData
    {
        [Fact]
        public void VerificaDataMenorQueDiaAtual()
        {
            //Arranje
            var pessoa = new Pessoa(1, "Matheus", "000.000.000-00", DateTime.Parse("14/12/1995"), 1, 1); ;
            //Act
            //Assert
            Assert.True(Pessoa.ValidaData(pessoa));
        }
        [Fact]
        public void VerificaDataMaiorQueDiaAtual()
        {
            //Arranje
            var pessoa = new Pessoa(1, "Matheus", "000.000.000-00", DateTime.Now.AddDays(1), 1, 1); ;
            //Act
            //Assert
            Assert.False(Pessoa.ValidaData(pessoa));
        }
        [Fact]
        public void VerificaDataIgualDiaAtual()
        {
            //Arranje
            var pessoa = new Pessoa(1, "Matheus", "000.000.000-00", DateTime.Now.Date, 1, 1); ;
            //Act
            //Assert
            Assert.False(Pessoa.ValidaData(pessoa));
        }
    }
}
