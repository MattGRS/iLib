using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly IEmprestimoAppServico _emprestimoAppServico;
        private readonly IExemplarLivroAppServico _exemplarLivroAppServico;
        private readonly ILivroAppServico _livroAppServico;

        public HomeController(IEmprestimoAppServico emprestimoAppServico, IExemplarLivroAppServico exemplarLivroAppServico, ILivroAppServico livroAppServico)
        {
            _emprestimoAppServico = emprestimoAppServico;
            _exemplarLivroAppServico = exemplarLivroAppServico;
            _livroAppServico = livroAppServico;
        }
        public ActionResult Index()
        {
            ViewBag.Emprestimos = BuscaEmprestimoCard();
            return View();
        }

        private IEnumerable<Emprestimo> BuscaEmprestimoCard()
        {
            var listaEmprestimo = _emprestimoAppServico.ObterTodos().Where(x => x.Status == StatusEmprestimo.Aberto).OrderBy(x => x.DataDevolucaoPrevista);
            foreach (var emprestimo in listaEmprestimo)
            {
                emprestimo.ExemplarLivro = _exemplarLivroAppServico.ObterPorId(emprestimo.ExemplarLivroId);
                emprestimo.ExemplarLivro.Livro = _livroAppServico.ObterPorId(emprestimo.ExemplarLivro.LivroId);
            }
            return listaEmprestimo;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}