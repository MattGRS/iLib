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
    public class EstadoController : Controller
    {
        private readonly IEstadoAppServico _estadoAppServico;
        private readonly IPaisAppServico _paisAppServico;
        public EstadoController(IEstadoAppServico estadoAppServico, IPaisAppServico paisAppServico)
        {
            _estadoAppServico = estadoAppServico;
            _paisAppServico = paisAppServico;
        }

        public ActionResult Index()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            return View(estadoViewModel);
        }

        public ActionResult Create()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisAppServico.ObterTodos());
            ViewBag.Pais = paisViewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EstadoViewModel estadoViewModel)
        {
            if (ModelState.IsValid)
            {
                var estadoEntidade = Mapper.Map<EstadoViewModel, Estado>(estadoViewModel);
                _estadoAppServico.Adicionar(estadoEntidade);

                return RedirectToAction("Index");
            }

            return View(estadoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var estadoEntidade = _estadoAppServico.ObterPorId(id);
            if (_estadoAppServico.Remover(estadoEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {estadoEntidade.NomeEstado} não pode ser removido pois existe um livro vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var estadoEntidade = _estadoAppServico.ObterPorId(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estadoEntidade);
            ViewBag.Estado = estadoViewModel;
            return View(estadoViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, EstadoViewModel estadoViewModel)
        {
            estadoViewModel.EstadoId = id;
            var estadoEntidade = Mapper.Map<EstadoViewModel, Estado>(estadoViewModel);
            _estadoAppServico.Atualizar(estadoEntidade);
            return RedirectToAction("Index");
        }
    }
}