using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
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
            foreach (var editora in editoraViewModel)
            {
                editora.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(editora.EnderecoId));
                editora.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(editora.Endereco.MunicipioId));
                editora.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(editora.Endereco.Municipio.EstadoId));
            }
            return View(editoraViewModel);
        }

        public ActionResult Create()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());
            ViewBag.Estado = estadoViewModel;
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

            editoraViewModel.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(editoraViewModel.EnderecoId));
            editoraViewModel.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(editoraViewModel.Endereco.MunicipioId));
            editoraViewModel.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(editoraViewModel.Endereco.Municipio.EstadoId));

            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoAppServico.ObterTodos());

            ViewBag.Estado = estadoViewModel;
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
        [HttpGet]
        public JsonResult SelecionarEnderecos(int id)
        {
            var todosEnderecosViewModel = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoAppServico.ObterTodos());
            var enderecoViewModel = todosEnderecosViewModel.Where(e => e.MunicipioId == id).ToList();
            return Json(enderecoViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(id));
            editoraViewModel.Endereco = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoAppServico.ObterPorId(editoraViewModel.EnderecoId));
            editoraViewModel.Endereco.Municipio = Mapper.Map<Municipio, MunicipioViewModel>(_municipioAppServico.ObterPorId(editoraViewModel.Endereco.MunicipioId));
            editoraViewModel.Endereco.Municipio.Estado = Mapper.Map<Estado, EstadoViewModel>(_estadoAppServico.ObterPorId(editoraViewModel.Endereco.Municipio.EstadoId));
            ViewBag.Editora = editoraViewModel;
            return View();
        }
    }
}