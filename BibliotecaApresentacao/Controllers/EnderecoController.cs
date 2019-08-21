using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoAppServico _enderecoAppServico;
        private readonly IMunicipioAppServico _municipioAppServico;
        private readonly IEstadoAppServico _estadoAppServico;
        public EnderecoController(IEnderecoAppServico enderecoAppServico, IMunicipioAppServico municipioAppServico, IEstadoAppServico estadoAppServico)
        {
            _enderecoAppServico = enderecoAppServico;
            _municipioAppServico = municipioAppServico;
            _estadoAppServico = estadoAppServico;
        }

        public ActionResult Index()
        {
            var enderecoViewModel = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoAppServico.ObterTodos());
            return View(enderecoViewModel);
        }

        public ActionResult Create()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            var municipioViewModel = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(_municipioAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
            ViewBag.Municipio = municipioViewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var enderecoEntidade = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
                _enderecoAppServico.Adicionar(enderecoEntidade);

                return RedirectToAction("Index");
            }

            return View(enderecoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var enderecoEntidade = _enderecoAppServico.ObterPorId(id);
            if (_enderecoAppServico.Remover(enderecoEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {enderecoEntidade.CEP} não pode ser removido pois existe uma pessoa ou editora vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var enderecoEntidade = _enderecoAppServico.ObterPorId(id);
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(enderecoEntidade);
            var municipioViewModel = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(_municipioAppServico.ObterTodos());
            ViewBag.Municipio = municipioViewModel;
            ViewBag.Endereco = enderecoViewModel;
            return View(enderecoViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, EnderecoViewModel enderecoViewModel)
        {
            enderecoViewModel.EnderecoId = id;
            var enderecoEntidade = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            _enderecoAppServico.Atualizar(enderecoEntidade);
            return RedirectToAction("Index");
        }
    }
}