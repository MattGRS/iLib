using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class ExemplarLivroController : Controller
    {
        private readonly IExemplarLivroAppServico _exemplarLivroAppServico;
        public ExemplarLivroController(IExemplarLivroAppServico exemplarLivroAppServico)
        {
            _exemplarLivroAppServico = exemplarLivroAppServico;
        }

        public ActionResult Index(int id)
        {
            var todosexemplarLivroViewModel = Mapper.Map<IEnumerable<ExemplarLivro>, IEnumerable<ExemplarLivroViewModel>>(_exemplarLivroAppServico.ObterTodos());
            var exemplarLivroViewModel = todosexemplarLivroViewModel.Where(e => e.LivroId == id).ToList().OrderBy(e => e.NumeroExemplar);

            ViewBag.LivroId = id;
            return View(exemplarLivroViewModel);
        }

        public ActionResult Create(int id)
        {
            ViewBag.LivroId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, ExemplarLivroViewModel exemplarLivroViewModel)
        {
            if (ModelState.IsValid)
            {
                exemplarLivroViewModel.LivroId = id;
                var exemplarLivroEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
                _exemplarLivroAppServico.Adicionar(exemplarLivroEntidade);

                return RedirectToAction($"Index/{id}");
            }

            return View(exemplarLivroViewModel);
        }

        public ActionResult Delete(int id)
        {
            var exemplarLivroEntidade = _exemplarLivroAppServico.ObterPorId(id);
            if (_exemplarLivroAppServico.Remover(exemplarLivroEntidade))
            {
                return RedirectToAction($"Index/{exemplarLivroEntidade.LivroId}");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {exemplarLivroEntidade.Registro} não pode ser removido pois existe um empréstimo em aberto vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var exemplarLivroEntidade = _exemplarLivroAppServico.ObterPorId(id);
            var exemplarLivroViewModel = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(exemplarLivroEntidade);
            ViewBag.ExemplarLivro = exemplarLivroViewModel;
            return View(exemplarLivroViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, ExemplarLivroViewModel exemplarLivroViewModel)
        {
            exemplarLivroViewModel.ExemplarLivroId = id;
            var exemplarLivroEntidade = Mapper.Map<ExemplarLivroViewModel, ExemplarLivro>(exemplarLivroViewModel);
            _exemplarLivroAppServico.Atualizar(exemplarLivroEntidade);
            return RedirectToAction($"Index/{exemplarLivroViewModel.LivroId}");
        }
    }
}