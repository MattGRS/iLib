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
        private readonly IEstadoAppServico _estadoAppServico;
        private readonly IEnderecoAppServico _enderecoAppServico;
        private readonly IMunicipioAppServico _municipioAppServico;
        public PessoaController(IPessoaAppServico pessoaAppServico, IEstadoAppServico estadoAppServico, IEnderecoAppServico enderecoAppServico, IMunicipioAppServico municipioAppServico)
        {
            _pessoaAppServico = pessoaAppServico;
            _estadoAppServico = estadoAppServico;
            _enderecoAppServico = enderecoAppServico;
            _municipioAppServico = municipioAppServico;
        }

        public ActionResult Index()
        {
            var pessoaViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaAppServico.ObterTodos());

            return View(pessoaViewModel);
        }

        public ActionResult Create()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
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
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            pessoaViewModel.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(pessoaViewModel.EnderecoId));
            pessoaViewModel.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(pessoaViewModel.Endereco.MunicipioId));
            pessoaViewModel.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(pessoaViewModel.Endereco.Municipio.EstadoId));
            ViewBag.Estado = estadoViewModel;
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

        private void MapeandoListaPessoa(IEnumerable<PessoaViewModel> pessoaViewModel)
        {
            foreach (var pessoa in pessoaViewModel)
            {
                pessoa.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(pessoa.EnderecoId));
                pessoa.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(pessoa.Endereco.MunicipioId));
                pessoa.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(pessoa.Endereco.Municipio.EstadoId));
            }
        }
    }
}