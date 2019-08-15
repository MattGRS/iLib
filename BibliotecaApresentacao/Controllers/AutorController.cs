using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorAppServico _autorAppServico;
        public AutorController(IAutorAppServico autorAppServico)
        {
            _autorAppServico = autorAppServico;
        }

        public ActionResult Index()
        {
            var autorViewModel = Mapper.Map<IEnumerable<Autor>, IEnumerable<AutorViewModel>>(_autorAppServico.ObterTodos());
            return View(autorViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autorEntidade = Mapper.Map<AutorViewModel, Autor>(autorViewModel);
                _autorAppServico.Adicionar(autorEntidade);

                return RedirectToAction("Index");
            }

            return View(autorViewModel);
        }

        public ActionResult Delete(int id)
        {
            var autorEntidade = _autorAppServico.ObterPorId(id);
            if (_autorAppServico.Remover(autorEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {autorEntidade.NomeAutor} não pode ser removido pois existe um livro vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var autorEntidade = _autorAppServico.ObterPorId(id);
            var autorViewModel = Mapper.Map<Autor, AutorViewModel>(autorEntidade);
            ViewBag.Autor = autorViewModel;
            return View(autorViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, AutorViewModel autorViewModel)
        {
            autorViewModel.AutorId = id;
            var autorEntidade = Mapper.Map<AutorViewModel, Autor>(autorViewModel);
            _autorAppServico.Atualizar(autorEntidade);
            return RedirectToAction("Index");
        }
    }
}