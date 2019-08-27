using AutoMapper;
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
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoAppServico _emprestimoAppServico;
        private readonly IPessoaAppServico _pessoaAppServico;
        private readonly IExemplarLivroAppServico _exemplarLivroAppServico;
        private readonly ILivroAppServico _livroAppServico;
        private readonly IAutorAppServico _autorAppServico;
        private readonly IAssuntoAppServico _assuntoAppServico;
        private readonly IEditoraAppServico _editoraAppServico;
        private readonly IClassificacaoAppServico _classificacaoAppServico;
        private readonly ILocalizacaoAppServico _localizacaoAppServico;

        public EmprestimoController(IEmprestimoAppServico emprestimoAppServico,
            IPessoaAppServico pessoaAppServico, 
            IExemplarLivroAppServico exemplarLivroAppServico, 
            ILivroAppServico livroAppServico,
            IAutorAppServico autorAppServico,
            IAssuntoAppServico assuntoAppServico,
            IEditoraAppServico editoraAppServico,
            IClassificacaoAppServico classificacaoAppServico,
            ILocalizacaoAppServico localizacaoAppServico)
        {
            _emprestimoAppServico = emprestimoAppServico;
            _pessoaAppServico = pessoaAppServico;
            _exemplarLivroAppServico = exemplarLivroAppServico;
            _livroAppServico = livroAppServico;
            _autorAppServico = autorAppServico;
            _assuntoAppServico = assuntoAppServico;
            _editoraAppServico = editoraAppServico;
            _classificacaoAppServico = classificacaoAppServico;
            _localizacaoAppServico = localizacaoAppServico;
        }
        public ActionResult Index()
        {
            var emprestimoViewModel = Mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoViewModel>>(_emprestimoAppServico.ObterTodos());

            foreach (var emprestimo in emprestimoViewModel)
            {
                emprestimo.Pessoa = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaAppServico.ObterPorId(emprestimo.PessoaId));
                emprestimo.ExemplarLivro = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(_exemplarLivroAppServico.ObterPorId(emprestimo.ExemplarLivroId));
                emprestimo.ExemplarLivro.Livro = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(emprestimo.ExemplarLivro.LivroId));
            }

            return View(emprestimoViewModel);
        }

        public ActionResult CreateStep1(int id)
        {
            var exemplarViewModel = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(_exemplarLivroAppServico.ObterPorId(id));
            exemplarViewModel.Livro = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(exemplarViewModel.LivroId));
            exemplarViewModel.Livro.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(exemplarViewModel.Livro.AutorId));
            exemplarViewModel.Livro.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(exemplarViewModel.Livro.AssuntoId));
            exemplarViewModel.Livro.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(exemplarViewModel.Livro.EditoraId));
            exemplarViewModel.Livro.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(exemplarViewModel.Livro.ClassificacaoId));
            exemplarViewModel.Livro.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(exemplarViewModel.Livro.LocalizacaoId));

            ViewBag.ExemplarLivro = exemplarViewModel;

            return View();
        }
        [HttpPost]
        public ActionResult CreateStep2(EmprestimoViewModel emprestimoViewModel)
        {
            var listaUsuarioViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaAppServico.ObterTodos());
            var usuarioViewModel = listaUsuarioViewModel.Where(p => p.Cpf == emprestimoViewModel.Pessoa.Cpf).First();

            var exemplarViewModel = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(_exemplarLivroAppServico.ObterPorId(emprestimoViewModel.ExemplarLivroId));
            exemplarViewModel.Livro = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(exemplarViewModel.LivroId));
            exemplarViewModel.Livro.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(exemplarViewModel.Livro.AutorId));
            exemplarViewModel.Livro.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(exemplarViewModel.Livro.AssuntoId));
            exemplarViewModel.Livro.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(exemplarViewModel.Livro.EditoraId));
            exemplarViewModel.Livro.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(exemplarViewModel.Livro.ClassificacaoId));
            exemplarViewModel.Livro.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(exemplarViewModel.Livro.LocalizacaoId));

            ViewBag.ExemplarLivro = exemplarViewModel;
            ViewBag.Usuario = usuarioViewModel;
            return View();
        }

        public ActionResult Confirm(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel.DataEmprestimo = DateTime.Now;
            emprestimoViewModel.DataDevolucao = DateTime.Now.AddDays(7);

            if (ModelState.IsValid)
            {
                var emprestimoEntidade = Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel);
                _emprestimoAppServico.Adicionar(emprestimoEntidade);
            }

            return RedirectToAction("Index");
        }
    }
}