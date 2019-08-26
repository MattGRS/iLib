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

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
    public class LivroController : Controller
    {
        private readonly ILivroAppServico _livroAppServico;
        private readonly IAutorAppServico _autorAppServico;
        private readonly IEditoraAppServico _editoraAppServico;
        private readonly IAssuntoAppServico _assuntoAppServico;
        private readonly ILocalizacaoAppServico _localizacaoAppServico;
        private readonly IClassificacaoAppServico _classificacaoAppServico;
        public LivroController(ILivroAppServico livroAppServico, IAutorAppServico autorAppServico, IEditoraAppServico editoraAppServico, IAssuntoAppServico assuntoAppServico, ILocalizacaoAppServico localizacaoAppServico, IClassificacaoAppServico classificacaoAppServico)
        {
            _livroAppServico = livroAppServico;
            _autorAppServico = autorAppServico;
            _editoraAppServico = editoraAppServico;
            _assuntoAppServico = assuntoAppServico;
            _localizacaoAppServico = localizacaoAppServico;
            _classificacaoAppServico = classificacaoAppServico;
        }

        public ActionResult Index()
        {
            var livroViewModel = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(_livroAppServico.ObterTodos());

            MapearPropriedadesListaLivro(livroViewModel);

            return View(livroViewModel);
        }

        public ActionResult Create()
        {
            CriaViewBagSelectLivro();

            return View();
        }
        [HttpPost]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                var livroEntidade = Mapper.Map<LivroViewModel, Livro>(livroViewModel);
                _livroAppServico.Adicionar(livroEntidade);

                return RedirectToAction("Index");
            }

            return View(livroViewModel);
        }

        public ActionResult Delete(int id)
        {
            var livroEntidade = _livroAppServico.ObterPorId(id);
            if (_livroAppServico.Remover(livroEntidade))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Erro", new { msg = $"O Iten {livroEntidade.Titulo} não pode ser removido pois existe um exemplar vinculado" });
        }

        public ActionResult Edit(int id)
        {
            var livroEntidade = _livroAppServico.ObterPorId(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livroEntidade);

            CriaViewBagSelectLivro();

            ViewBag.Livro = livroViewModel;
            return View(livroViewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, LivroViewModel livroViewModel)
        {
            livroViewModel.LivroId = id;
            var livroEntidade = Mapper.Map<LivroViewModel, Livro>(livroViewModel);
            _livroAppServico.Atualizar(livroEntidade);
            return RedirectToAction($"Details/{id}");
        }

        public ActionResult Details(int id)
        {
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(id));

            MapearPropriedadesLivro(livroViewModel);

            ViewBag.Livro = livroViewModel;

            return View();
        }

        private void MapearPropriedadesLivro(LivroViewModel livroViewModel)
        {
            livroViewModel.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(livroViewModel.AutorId));
            livroViewModel.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(livroViewModel.EditoraId));
            livroViewModel.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(livroViewModel.AssuntoId));
            livroViewModel.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(livroViewModel.LocalizacaoId));
            livroViewModel.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(livroViewModel.ClassificacaoId));
        }

        public void MapearPropriedadesListaLivro(IEnumerable<LivroViewModel> livroViewModel)
        {
            foreach (var livro in livroViewModel)
            {
                livro.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(livro.AutorId));
                livro.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(livro.EditoraId));
                livro.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(livro.AssuntoId));
                livro.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(livro.LocalizacaoId));
                livro.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(livro.ClassificacaoId));
            }
        }

        public void CriaViewBagSelectLivro()
        {
            var autorViewModel = Mapper.Map<IEnumerable<Autor>, IEnumerable<AutorViewModel>>(_autorAppServico.ObterTodos());
            var editoraViewModel = Mapper.Map<IEnumerable<Editora>, IEnumerable<EditoraViewModel>>(_editoraAppServico.ObterTodos());
            var assuntoViewModel = Mapper.Map<IEnumerable<Assunto>, IEnumerable<AssuntoViewModel>>(_assuntoAppServico.ObterTodos());
            var localizacaoViewModel = Mapper.Map<IEnumerable<Localizacao>, IEnumerable<LocalizacaoViewModel>>(_localizacaoAppServico.ObterTodos());
            var classificacaoViewModel = Mapper.Map<IEnumerable<Classificacao>, IEnumerable<ClassificacaoViewModel>>(_classificacaoAppServico.ObterTodos());
            ViewBag.Autor = autorViewModel;
            ViewBag.Editora = editoraViewModel;
            ViewBag.Assunto = assuntoViewModel;
            ViewBag.Localizacao = localizacaoViewModel;
            ViewBag.Classificacao = classificacaoViewModel;
        }
    }
}