using AutoMapper;
using BibliotecaAplicacao.Classes;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    public class EditoraController : Controller
    {
        private readonly IEditoraAppServico _editoraAppServico;
        private readonly IEnderecoAppServico _enderecoAppServico;
        private readonly IMunicipioAppServico _municipioAppServico;
        private readonly IEstadoAppServico _estadoAppServico;
        public EditoraController(IEditoraAppServico editoraAppServico, IEnderecoAppServico enderecoAppServico, IMunicipioAppServico municipioAppServico, IEstadoAppServico estadoAppServico)
        {
            _editoraAppServico = editoraAppServico;
            _enderecoAppServico = enderecoAppServico;
            _municipioAppServico = municipioAppServico;
            _estadoAppServico = estadoAppServico;
        }

        public ActionResult Index()
        {
            var editoraViewModel = Mapper.Map<IEnumerable<Editora>, IEnumerable<EditoraViewModel>>(_editoraAppServico.ObterTodos());
            return View(editoraViewModel);
        }

        public ActionResult Create()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            var municipioViewModel = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(_municipioAppServico.ObterTodos());
            var enderecoViewModel = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
            ViewBag.Municipio = municipioViewModel;
            ViewBag.Endereco = enderecoViewModel;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EditoraViewModel editoraViewModel)
        {
            if (ModelState.IsValid)
            {
                var editoraEntidade = Mapper.Map<EditoraViewModel, Editora>(editoraViewModel);
                _editoraAppServico.Adicionar(editoraEntidade);

                return RedirectToAction("Index");
            }

            return View(editoraViewModel);
        }

        public ActionResult Delete(int id)
        {
            var editoraEntidade = _editoraAppServico.ObterPorId(id);
            if (_editoraAppServico.Remover(editoraEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {editoraEntidade.NomeEditora} não pode ser removido pois existe um livro vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var editoraEntidade = _editoraAppServico.ObterPorId(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editoraEntidade);
            ViewBag.Editora = editoraViewModel;
            return View(editoraViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, EditoraViewModel editoraViewModel)
        {
            editoraViewModel.EditoraId = id;
            var editoraEntidade = Mapper.Map<EditoraViewModel, Editora>(editoraViewModel);
            _editoraAppServico.Atualizar(editoraEntidade);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult SelecionarMunicipios(int id)
        {
            var todosMunicipioViewModel = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(_municipioAppServico.ObterTodos());

            var municipioViewModel = todosMunicipioViewModel.Where(m => m.EstadoId == id).ToList();

            return Json(municipioViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}