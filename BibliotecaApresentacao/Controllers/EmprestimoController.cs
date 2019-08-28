using AutoMapper;
using BibliotecaAplicacao.Interfaces;
using BibliotecaApresentacao.Filter;
using BibliotecaApresentacao.Negocio;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BibliotecaApresentacao.Controllers
{
    [AuthorizationFilter]
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
        

        public EmprestimoController
            (IEmprestimoAppServico emprestimoAppServico,
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
            GerarViewBagStep1(exemplarViewModel);

            return View();
        }


        [HttpPost]
        public ActionResult CreateStep2(EmprestimoViewModel emprestimoViewModel)
        {
            var listaUsuarioViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaAppServico.ObterTodos());
            var usuarioViewModel = listaUsuarioViewModel.Where(p => p.Cpf == emprestimoViewModel.Pessoa.Cpf).First();
            GerarViewBagStep2(emprestimoViewModel, usuarioViewModel);
            return View();
        }

        public ActionResult Confirm(EmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                var emprestimoEntidade = Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel);
                
                /**************************Atualiza Exemplar***********************/
                emprestimoEntidade.ExemplarLivro.MarcaExemplarLivroComoEmprestado();
                _exemplarLivroAppServico.Atualizar(emprestimoEntidade.ExemplarLivro);
                
                /**********Adiciona Emprestimo************/
                emprestimoEntidade.Emprestar();
                emprestimoEntidade.ExemplarLivro = null;
                _emprestimoAppServico.Adicionar(emprestimoEntidade);

            }

            return RedirectToAction("Index");
        }

        public ActionResult Return(int id)
        {
            /***************Atualiza Emprestimo***************/
            var emprestimo = _emprestimoAppServico.ObterTodos()
                .Where(p => p.ExemplarLivroId == id)
                .OrderBy(p => p.DataEmprestimo)
                .Last();
            emprestimo.Devolver();
            _emprestimoAppServico.Atualizar(emprestimo);
            /***************Atualiza Exemplar**************/
            var exemplar = _exemplarLivroAppServico.ObterPorId(id);
            exemplar.MarcaExemplarLivroComoDisponivel();
            _exemplarLivroAppServico.Atualizar(exemplar);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var emprestimo = _emprestimoAppServico.ObterPorId(id);
            var exemplar = _exemplarLivroAppServico.ObterPorId(emprestimo.ExemplarLivroId);
            var livro = _livroAppServico.ObterPorId(exemplar.LivroId);
            var autor = _autorAppServico.ObterPorId(livro.AutorId);
            var editora = _editoraAppServico.ObterPorId(livro.EditoraId);
            var pessoa = _pessoaAppServico.ObterPorId(emprestimo.PessoaId);
            
            //Emprestimo
            ViewBag.DataEmprestimo = emprestimo.DataEmprestimo;
            ViewBag.DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista;
            ViewBag.DataDevolucaoRealizada = emprestimo.DataDevolucaoRealizada;
            //exemplar
            ViewBag.Registro = exemplar.Registro;
            ViewBag.NumeroExemplar = exemplar.NumeroExemplar;
            //Livro
            ViewBag.Titulo = livro.Titulo;
            ViewBag.Editora = editora.NomeEditora;
            ViewBag.Autor = autor.NomeAutor;
            ViewBag.LivroId = livro.LivroId;
            //Usuário
            ViewBag.Nome = pessoa.Nome;
            ViewBag.Telefone = pessoa.Telefone;
            ViewBag.Email = pessoa.Email;
            ViewBag.PessoaId = pessoa.PessoaId;

            return View();
        }

        private void GerarViewBagStep1(ExemplarLivroViewModel exemplarViewModel)
        {
            ViewBag.Livro = exemplarViewModel.Livro = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(exemplarViewModel.LivroId));
            ViewBag.Autor = exemplarViewModel.Livro.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(exemplarViewModel.Livro.AutorId));
            ViewBag.Assunto = exemplarViewModel.Livro.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(exemplarViewModel.Livro.AssuntoId));
            ViewBag.Editora = exemplarViewModel.Livro.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(exemplarViewModel.Livro.EditoraId));
            ViewBag.Classificacao = exemplarViewModel.Livro.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(exemplarViewModel.Livro.ClassificacaoId));
            ViewBag.Localizacao = exemplarViewModel.Livro.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(exemplarViewModel.Livro.LocalizacaoId));
            ViewBag.ExemplarLivro = exemplarViewModel;
        }

        private void GerarViewBagStep2(EmprestimoViewModel emprestimoViewModel, PessoaViewModel usuarioViewModel)
        {
            ViewBag.Titulo = emprestimoViewModel.ExemplarLivro.Livro.Titulo;
            ViewBag.Autor = emprestimoViewModel.ExemplarLivro.Livro.Autor.NomeAutor;
            ViewBag.Editora = emprestimoViewModel.ExemplarLivro.Livro.Editora.NomeEditora;
            ViewBag.Assunto = emprestimoViewModel.ExemplarLivro.Livro.Assunto.AssuntoObra;
            ViewBag.Classificacao = emprestimoViewModel.ExemplarLivro.Livro.Classificacao.ClassificacaoObra;
            ViewBag.Localizacao = emprestimoViewModel.ExemplarLivro.Livro.Localizacao.LocalizacaoObra;
            ViewBag.ExemplarLivro = emprestimoViewModel.ExemplarLivro;
            ViewBag.Usuario = usuarioViewModel;
        }
    }
}