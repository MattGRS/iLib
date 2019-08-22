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
    public class DadosLoginController : Controller
    {
        private readonly IDadosLoginAppServico _dadosLoginAppServico;
        public DadosLoginController(IDadosLoginAppServico dadosLoginAppServico)
        {
            _dadosLoginAppServico = dadosLoginAppServico;
        }
        // GET: DadosLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(DadosLoginViewModel dadosLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var dadosLoginEntidade = Mapper.Map<DadosLoginViewModel, DadosLogin>(dadosLoginViewModel);
                _dadosLoginAppServico.Adicionar(dadosLoginEntidade);

                return RedirectToAction($"Create{dadosLoginViewModel.DadosLoginId}", "Pessoa");
            }
            return View(dadosLoginViewModel);
        }
    }
}