using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
    public class ClassificacaoController : Controller
    {
        private readonly IClassificacaoAppServico _classificacaoAppServico;
        public ClassificacaoController(IClassificacaoAppServico classificacaoAppServico)
        {
            _classificacaoAppServico = classificacaoAppServico;
        }

        public ActionResult Index()
        {
            var classificacaoViewModel = Mapper.Map<IEnumerable<Classificacao>, IEnumerable<ClassificacaoViewModel>>(_classificacaoAppServico.ObterTodos());
            return View(classificacaoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ClassificacaoViewModel classificacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var classificacaoEntidade = Mapper.Map<ClassificacaoViewModel, Classificacao>(classificacaoViewModel);
                _classificacaoAppServico.Adicionar(classificacaoEntidade);

                return RedirectToAction("Index");
            }

            return View(classificacaoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var classificacaoEntidade = _classificacaoAppServico.ObterPorId(id);
            if (_classificacaoAppServico.Remover(classificacaoEntidade))
            {
                return RedirectToAction("Index");
            }

            TempData["msg"] = $"O Iten {classificacaoEntidade.ClassificacaoObra} não pode ser removido pois existe um livro vinculado";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var classificacaoEntidade = _classificacaoAppServico.ObterPorId(id);
            var classificacaoViewModel = Mapper.Map<Classificacao, ClassificacaoViewModel>(classificacaoEntidade);
            ViewBag.Classificacao = classificacaoViewModel;
            return View(classificacaoViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, ClassificacaoViewModel classificacaoViewModel)
        {
            classificacaoViewModel.ClassificacaoId = id;
            var classificacaoEntidade = Mapper.Map<ClassificacaoViewModel, Classificacao>(classificacaoViewModel);
            _classificacaoAppServico.Atualizar(classificacaoEntidade);
            return RedirectToAction("Index");
        }
    }
}