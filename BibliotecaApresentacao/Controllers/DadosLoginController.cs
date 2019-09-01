using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BibliotecaApresentacao.Controllers
{
    public class DadosLoginController : Controller
    {
        private readonly IDadosLoginAppServico _dadosLoginAppServico;
        private readonly IPessoaAppServico _pessoaAppServico;
        public DadosLoginController(IDadosLoginAppServico dadosLoginAppServico, IPessoaAppServico pessoaAppServico)
        {
            _dadosLoginAppServico = dadosLoginAppServico;
            _pessoaAppServico = pessoaAppServico;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authentication(string login, string senha)
        {
            var usuario = _dadosLoginAppServico.SearchUser(login, senha);
            if (usuario != null)
            {
                Session["usuarioAutenticado"] = usuario;
                Session["usuarioId"] = usuario.DadosLoginId;
                var pessoa = BuscarPessoaPorUsuario(usuario);
                Session["pessoaId"] = pessoa.PessoaId;
                Session["Nome"] = pessoa.Nome;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "login inválido.");
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();

            return RedirectToAction("Index");
        }

        [AuthorizationFilter]
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

                var usuarioId = BuscarIdUsuario(dadosLoginEntidade);

                return RedirectToAction($"Create/{usuarioId}", "Pessoa");
            }
            return View(dadosLoginViewModel);
        }

        private int BuscarIdUsuario(DadosLogin dadosLoginEntidade)
        {
            var usuarios = Mapper.Map<IEnumerable<DadosLogin>, IEnumerable<DadosLoginViewModel>>(_dadosLoginAppServico.ObterTodos());
            var usuarioProcurado = usuarios.First(x => x.Login == dadosLoginEntidade.Login);
            return usuarioProcurado.DadosLoginId;
        }

        private Pessoa BuscarPessoaPorUsuario(DadosLogin dadosLogin)
        {
            var pessoa = _pessoaAppServico.ObterTodos();
            var pessoaProcurado = pessoa.FirstOrDefault(x => x.DadosLoginId == dadosLogin.DadosLoginId);
            return pessoaProcurado;
        }
    }
}