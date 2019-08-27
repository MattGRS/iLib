using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaApresentacao.Negocio
{
    public class ExemplarNegocio
    {
        public void MarcaExemplarLivroComoDisponivel(ExemplarLivroViewModel exemplarLivroViewModel, IExemplarLivroAppServico exemplarLivroAppServico)
        {
            exemplarLivroViewModel.Status = StatusExemplarLivro.Disponivel;
            var exemplarEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
            exemplarLivroAppServico.Atualizar(exemplarEntidade);
        }

        public void MarcaExemplarLivroComoEmprestado(ExemplarLivroViewModel exemplarLivroViewModel, IExemplarLivroAppServico exemplarLivroAppServico)
        {
            exemplarLivroViewModel.Status = StatusExemplarLivro.Indisponivel;
            var exemplarEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
            exemplarLivroAppServico.Atualizar(exemplarEntidade);

        }

    }
}