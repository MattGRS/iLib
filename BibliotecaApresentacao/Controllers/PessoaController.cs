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
            MapeiaEnderecoDePessoa(pessoaViewModel);
            ViewBag.Pessoa = pessoaViewModel;
            ViewBag.Endereco = $"{pessoaViewModel.Endereco.Logradouro}, " +
                $"{pessoaViewModel.Endereco.NumeroResidencial}" +
                $" - {pessoaViewModel.Endereco.Bairro}";
            ViewBag.Municipio = pessoaViewModel.Endereco.Municipio.NomeMunicipio;
            ViewBag.Estado = pessoaViewModel.Endereco.Municipio.Estado.NomeEstado;
            return View(pessoaViewModel);
        }

        public ActionResult Create(int id)
        {
            GeraViewBagCreate(id);
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id, PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                pessoaViewModel.DadosLoginId = id;
                var pessoaEntidade = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);
                if (pessoaEntidade.ValidaData(pessoaEntidade))
                {
                    _pessoaAppServico.Adicionar(pessoaEntidade);
                    return RedirectToAction("Index");

                }

                TempData["msg"] = "Data de Nascimento inválida!";
            }

            GeraViewBagCreate(id);

            return View(pessoaViewModel);
        }

        public ActionResult Delete(int id)
        {
            var pessoaEntidade = _pessoaAppServico.ObterPorId(id);
            if (_pessoaAppServico.Remover(pessoaEntidade))
            {
                return RedirectToAction("Index");
            }

            TempData["msg"] = $"O Item {pessoaEntidade.Nome} não pode ser removido pois existe um empréstimo vinculado!";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaAppServico.ObterPorId(id));
            MapeiaEnderecoDePessoa(pessoaViewModel);
            ViewBag.Estado = _estadoAppServico.ObterTodos();

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

        private void MapeiaEnderecoDePessoa(PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(pessoaViewModel.EnderecoId));
            pessoaViewModel.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(pessoaViewModel.Endereco.MunicipioId));
            pessoaViewModel.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(pessoaViewModel.Endereco.Municipio.EstadoId));   
        }

        private void GeraViewBagCreate(int id)
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
            ViewBag.UsuarioId = id;
        }
    }
}