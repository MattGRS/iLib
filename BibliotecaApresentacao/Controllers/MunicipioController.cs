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
    public class MunicipioController : Controller
    {
        private readonly IMunicipioAppServico _municipioAppServico;
        private readonly IEstadoAppServico _estadoAppServico;
        public MunicipioController(IMunicipioAppServico municipioAppServico, IEstadoAppServico estadoAppServico)
        {
            _municipioAppServico = municipioAppServico;
            _estadoAppServico = estadoAppServico;
        }

        public ActionResult Index()
        {
            var municipioViewModel = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(_municipioAppServico.ObterTodos());
            return View(municipioViewModel);
        }

        public ActionResult Create()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Create(MunicipioViewModel municipioViewModel)
        {
            if (ModelState.IsValid)
            {
                var municipioEntidade = Mapper.Map<MunicipioViewModel, Municipio>(municipioViewModel);
                _municipioAppServico.Adicionar(municipioEntidade);

                return RedirectToAction("Index");
            }

            return View(municipioViewModel);
        }

        public ActionResult Delete(int id)
        {
            var municipioEntidade = _municipioAppServico.ObterPorId(id);
            if (_municipioAppServico.Remover(municipioEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {municipioEntidade.NomeMunicipio} não pode ser removido pois existe um livro vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;

            var municipioEntidade = _municipioAppServico.ObterPorId(id);
            var municipioViewModel = Mapper.Map<Municipio, MunicipioViewModel>(municipioEntidade);
            ViewBag.Municipio = municipioViewModel;
            return View(municipioViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, MunicipioViewModel municipioViewModel)
        {
            municipioViewModel.MunicipioId = id;
            var municipioEntidade = Mapper.Map<MunicipioViewModel, Municipio>(municipioViewModel);
            _municipioAppServico.Atualizar(municipioEntidade);
            return RedirectToAction("Index");
        }
    }
}