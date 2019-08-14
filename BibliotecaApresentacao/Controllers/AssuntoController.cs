using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class AssuntoController : Controller
    {
        private readonly IAssuntoAppServico _assuntoAppServico;
        public AssuntoController(IAssuntoAppServico assuntoAppServico)
        {
            _assuntoAppServico = assuntoAppServico;
        }
        // GET: Assunto
        public ActionResult Index()
        {
            var assuntoViewModel = Mapper.Map<IEnumerable<Assunto>, IEnumerable<AssuntoViewModel>>(_assuntoAppServico.ObterTodos());
            return View(assuntoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AssuntoViewModel assuntoViewModel)
        {
            if (ModelState.IsValid)
            {
                var assuntoEntidade = Mapper.Map<AssuntoViewModel, Assunto>(assuntoViewModel);
                _assuntoAppServico.Adicionar(assuntoEntidade);

                return RedirectToAction("Index");
            }

            return View(assuntoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var categoriaEntidade = _assuntoAppServico.ObterPorId(id);
            if (_assuntoAppServico.Remover(categoriaEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {categoriaEntidade.AssuntoObra} não pode ser removido pois existe um livro vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var assuntoEntidade = _assuntoAppServico.ObterPorId(id);
            var assuntoViewModel = Mapper.Map<Assunto, AssuntoViewModel>(assuntoEntidade);
            ViewBag.Assunto = assuntoViewModel;
            return View(assuntoEntidade);
        }

        public ActionResult EditSave(int id, AssuntoViewModel assuntoViewModel)
        {
            assuntoViewModel.AssuntoId = id;
            var assuntoEntidade = Mapper.Map<AssuntoViewModel, Assunto>(assuntoViewModel);
            _assuntoAppServico.Atualizar(assuntoEntidade);
            return RedirectToAction("Index");
        }
    }
}