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
    }
}