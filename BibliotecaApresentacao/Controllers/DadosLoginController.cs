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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DadosLoginViewModel dadosLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var dadosLoginEntidade = Mapper.Map<DadosLoginViewModel, DadosLogin>(dadosLoginViewModel);
                _dadosLoginAppServico.Adicionar(dadosLoginEntidade);

                var usuarioId = BuscarUsuario(dadosLoginEntidade);

                return RedirectToAction($"Create/{usuarioId}", "Pessoa");
            }
            return View(dadosLoginViewModel);
        }

        private int BuscarUsuario(DadosLogin dadosLoginEntidade)
        {
            var usuarios = Mapper.Map<IEnumerable<DadosLogin>, IEnumerable<DadosLoginViewModel>>(_dadosLoginAppServico.ObterTodos());
            var usuarioProcurado = usuarios.First(x => x.Login == dadosLoginEntidade.Login);
            return usuarioProcurado.DadosLoginId;
        }
    }
}