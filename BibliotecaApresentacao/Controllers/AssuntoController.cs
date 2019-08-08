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
    public class AssuntoController : Controller
    {
        private readonly IAssuntoServico _assuntoServico;
        public AssuntoController(IAssuntoServico assuntoServico)
        {
            _assuntoServico = assuntoServico;
        }

        public AssuntoController()
        {

        }
        // GET: Assunto
        public ActionResult Index()
        {
            var assuntoViewModel = Mapper.Map<IEnumerable<Assunto>, IEnumerable<AssuntoViewModel>>(_assuntoServico.ObterTodos());
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
                _assuntoServico.Adicionar(assuntoEntidade);

                return RedirectToAction("Index");
            }

            return View(assuntoViewModel);
        }
    }
}