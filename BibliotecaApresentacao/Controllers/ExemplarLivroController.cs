using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
    public class ExemplarLivroController : Controller
    {
        private readonly IExemplarLivroAppServico _exemplarLivroAppServico;
        private readonly ILivroAppServico _livroAppServico;
        public ExemplarLivroController(IExemplarLivroAppServico exemplarLivroAppServico, ILivroAppServico livroAppServico)
        {
            _exemplarLivroAppServico = exemplarLivroAppServico;
            _livroAppServico = livroAppServico;
        }

        public ActionResult Index(int id)
        {
            var todosexemplarLivroViewModel = Mapper.Map<IEnumerable<ExemplarLivro>, IEnumerable<ExemplarLivroViewModel>>(_exemplarLivroAppServico.ObterTodos());
            var exemplarLivroViewModel = todosexemplarLivroViewModel.Where(e => e.LivroId == id).ToList().OrderBy(e => e.NumeroExemplar);

            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(id));

            ViewBag.LivroTitulo = livroViewModel.Titulo;

            ViewBag.LivroId = id;
            return View(exemplarLivroViewModel);
        }

        public ActionResult Create(int id)
        {
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(id));

            ViewBag.LivroTitulo = livroViewModel.Titulo;

            ViewBag.LivroId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, ExemplarLivroViewModel exemplarLivroViewModel)
        {
            if (ModelState.IsValid)
            {
                exemplarLivroViewModel.LivroId = id;
                exemplarLivroViewModel.Status = StatusExemplarLivro.Disponivel;
                var exemplarLivroEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
                _exemplarLivroAppServico.Adicionar(exemplarLivroEntidade);

                return RedirectToAction($"Index/{id}");
            }

            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(id));
            ViewBag.LivroTitulo = livroViewModel.Titulo;
            ViewBag.LivroId = id;

            return View(exemplarLivroViewModel);
        }

        public ActionResult Delete(int id)
        {
            var exemplarLivroEntidade = _exemplarLivroAppServico.ObterPorId(id);
            if (_exemplarLivroAppServico.Remover(exemplarLivroEntidade))
            {
                return RedirectToAction($"Index/{exemplarLivroEntidade.LivroId}");
            }

            TempData["msg"] = $"O Item {exemplarLivroEntidade.Registro} não pode ser removido pois existe um empréstimo em aberto vinculado!";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var exemplarLivroEntidade = _exemplarLivroAppServico.ObterPorId(id);
            var exemplarLivroViewModel = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(exemplarLivroEntidade);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(exemplarLivroViewModel.LivroId));
            ViewBag.ExemplarLivroId = id;
            ViewBag.ExemplarLivro = exemplarLivroViewModel;
            ViewBag.LivroTitulo = livroViewModel.Titulo;
            return View(exemplarLivroViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ExemplarLivroViewModel exemplarLivroViewModel)
        {
            if (ModelState.IsValid)
            {
                var exemplarLivroEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
                _exemplarLivroAppServico.Atualizar(exemplarLivroEntidade);
                return RedirectToAction($"Index/{exemplarLivroViewModel.LivroId}");
            }

            return View(exemplarLivroViewModel);
        }
    }
}