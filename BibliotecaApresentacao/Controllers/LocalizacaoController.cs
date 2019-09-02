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
    public class LocalizacaoController : Controller
    {
        private readonly ILocalizacaoAppServico _localizacaoAppServico;
        public LocalizacaoController(ILocalizacaoAppServico localizacaoAppServico)
        {
            _localizacaoAppServico = localizacaoAppServico;
        }

        public ActionResult Index()
        {
            var localizacaoViewModel = Mapper.Map<IEnumerable<Localizacao>, IEnumerable<LocalizacaoViewModel>>(_localizacaoAppServico.ObterTodos());
            return View(localizacaoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LocalizacaoViewModel localizacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var localizacaoEntidade = Mapper.Map<LocalizacaoViewModel, Localizacao>(localizacaoViewModel);
                _localizacaoAppServico.Adicionar(localizacaoEntidade);

                return RedirectToAction("Index");
            }

            return View(localizacaoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var localizacaoEntidade = _localizacaoAppServico.ObterPorId(id);
            if (_localizacaoAppServico.Remover(localizacaoEntidade))
            {
                return RedirectToAction("Index");
            }

            TempData["msg"] = $"O Item {localizacaoEntidade.LocalizacaoObra} não pode ser removido pois existe um livro vinculado!";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var localizacaoEntidade = _localizacaoAppServico.ObterPorId(id);
            var localizacaoViewModel = Mapper.Map<Localizacao, LocalizacaoViewModel>(localizacaoEntidade);
            ViewBag.Localizacao = localizacaoViewModel;
            return View(localizacaoViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, LocalizacaoViewModel localizacaoViewModel)
        {
            localizacaoViewModel.LocalizacaoId = id;
            var localizacaoEntidade = Mapper.Map<LocalizacaoViewModel, Localizacao>(localizacaoViewModel);
            _localizacaoAppServico.Atualizar(localizacaoEntidade);
            return RedirectToAction("Index");
        }
    }
}