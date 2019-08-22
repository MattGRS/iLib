using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaAppServico _pessoaAppServico;
        public PessoaController(IPessoaAppServico pessoaAppServico)
        {
            _pessoaAppServico = pessoaAppServico;
        }

        public ActionResult Index()
        {
            var pessoaViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaAppServico.ObterTodos());
            return View(pessoaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                var pessoaEntidade = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);
                _pessoaAppServico.Adicionar(pessoaEntidade);

                return RedirectToAction("Index");
            }

            return View(pessoaViewModel);
        }

        public ActionResult Delete(int id)
        {
            var pessoaEntidade = _pessoaAppServico.ObterPorId(id);
            if (_pessoaAppServico.Remover(pessoaEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {pessoaEntidade.Nome} não pode ser removido pois existe um usuário vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var pessoaEntidade = _pessoaAppServico.ObterPorId(id);
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoaEntidade);
            ViewBag.Pessoa = pessoaViewModel;
            return View(pessoaViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.PessoaId = id;
            var pessoaEntidade = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);
            _pessoaAppServico.Atualizar(pessoaEntidade);
            return RedirectToAction("Index");
        }
    }
}