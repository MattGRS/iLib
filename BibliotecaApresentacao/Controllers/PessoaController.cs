using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
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

        public ActionResult Details(int id)
        {
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaAppServico.ObterPorId(id));
            MapeiaEndereco(pessoaViewModel);
            ViewBag.Pessoa = pessoaViewModel;
            ViewBag.Endereco = $"{pessoaViewModel.Endereco.Logradouro}, " +
                $"{pessoaViewModel.Endereco.NumeroResidencial}" +
                $" - {pessoaViewModel.Endereco.Bairro}";
            ViewBag.Municipio = pessoaViewModel.Endereco.Municipio.NomeMunicipio;
            ViewBag.Estado = pessoaViewModel.Endereco.Municipio.Estado.NomeEstado;
            return View();
        }

        public ActionResult Create(int id)
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
            ViewBag.UsuarioId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                pessoaViewModel.DadosLoginId = id;
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

        private void MapeiaEndereco(PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(pessoaViewModel.EnderecoId));
            pessoaViewModel.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(pessoaViewModel.Endereco.MunicipioId));
            pessoaViewModel.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(pessoaViewModel.Endereco.Municipio.EstadoId));   
        }
    }
}