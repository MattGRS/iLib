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
    public class PaisController : Controller
    {
        private readonly IPaisAppServico _paisAppServico;
        public PaisController(IPaisAppServico paisAppServico)
        {
            _paisAppServico = paisAppServico;
        }

        public ActionResult Index()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisAppServico.ObterTodos());
            return View(paisViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PaisViewModel paisViewModel)
        {
            if (ModelState.IsValid)
            {
                var paisEntidade = Mapper.Map<PaisViewModel, Pais>(paisViewModel);
                _paisAppServico.Adicionar(paisEntidade);

                return RedirectToAction("Index");
            }

            return View(paisViewModel);
        }

        public ActionResult Delete(int id)
        {
            var paisEntidade = _paisAppServico.ObterPorId(id);
            if (_paisAppServico.Remover(paisEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {paisEntidade.NomePais} não pode ser removido pois existe um estado vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var paisEntidade = _paisAppServico.ObterPorId(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(paisEntidade);
            ViewBag.Pais = paisViewModel;
            return View(paisViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, PaisViewModel paisViewModel)
        {
            paisViewModel.PaisId = id;
            var paisEntidade = Mapper.Map<PaisViewModel, Pais>(paisViewModel);
            _paisAppServico.Atualizar(paisEntidade);
            return RedirectToAction("Index");
        }
    }
}