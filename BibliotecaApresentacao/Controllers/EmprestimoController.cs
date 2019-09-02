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
            var emprestimoViewModel = Mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoViewModel>>(_emprestimoAppServico.ObterTodos().OrderBy(x => x.Status).ThenByDescending(m => m.DataEmprestimo));

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
            var emprestimoViewModel = new EmprestimoViewModel();
            emprestimoViewModel.ExemplarLivroId = id;
            MapearUmExemplar(emprestimoViewModel);

            return View(emprestimoViewModel);
        }

        [HttpPost]
        public ActionResult CreateStep2(EmprestimoViewModel emprestimoViewModel)
        {
            var listaUsuarioViewModel = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaAppServico.ObterTodos());
            emprestimoViewModel.Pessoa = listaUsuarioViewModel
                .Where(p => p.Cpf == emprestimoViewModel.Pessoa.Cpf)
                .FirstOrDefault();
            if (emprestimoViewModel.Pessoa != null)
            {
                MapearUmExemplar(emprestimoViewModel);

                return View(emprestimoViewModel);
            }

            TempData["msg"] = "CPF não encontrado!";

            return RedirectToAction($"CreateStep1/{emprestimoViewModel.ExemplarLivroId}");
        }

        public ActionResult Confirm(EmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                var emprestimoEntidade = Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel);

                var exemplarEntidade = _exemplarLivroAppServico.ObterPorId(emprestimoViewModel.ExemplarLivroId);

                /**************************Atualiza Exemplar***********************/
                exemplarEntidade.MarcaExemplarLivroComoEmprestado();
                _exemplarLivroAppServico.Atualizar(exemplarEntidade);
                
                /**********Adiciona Emprestimo************/
                emprestimoEntidade.Emprestar();
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
            var emprestimoViewModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(_emprestimoAppServico.ObterPorId(id));

            MapearUmExemplar(emprestimoViewModel);
            emprestimoViewModel.Pessoa = Mapper.Map<Pessoa, PessoaViewModel>(_pessoaAppServico.ObterPorId(emprestimoViewModel.PessoaId));

            return View(emprestimoViewModel);
        }

        public ActionResult Renew(int id)
        {
            var emprestimoEntidade = _emprestimoAppServico.ObterPorId(id);
            emprestimoEntidade.Devolver();
            _emprestimoAppServico.Atualizar(emprestimoEntidade);

            var novoEmprestimoEntidade = new Emprestimo
            {
                ExemplarLivroId = emprestimoEntidade.ExemplarLivroId,
                PessoaId = emprestimoEntidade.PessoaId
            };

            novoEmprestimoEntidade.Emprestar();
            _emprestimoAppServico.Adicionar(novoEmprestimoEntidade);

            return RedirectToAction("Index");
        }

        private void MapearUmExemplar(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel.ExemplarLivro = Mapper.Map<ExemplarLivro, ExemplarLivroViewModel>(_exemplarLivroAppServico.ObterPorId(emprestimoViewModel.ExemplarLivroId));
            emprestimoViewModel.ExemplarLivro.Livro = Mapper.Map<Livro, LivroViewModel>(_livroAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.LivroId));
            emprestimoViewModel.ExemplarLivro.Livro.Autor = Mapper.Map<Autor, AutorViewModel>(_autorAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.Livro.AutorId));
            emprestimoViewModel.ExemplarLivro.Livro.Assunto = Mapper.Map<Assunto, AssuntoViewModel>(_assuntoAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.Livro.AssuntoId));
            emprestimoViewModel.ExemplarLivro.Livro.Editora = Mapper.Map<Editora, EditoraViewModel>(_editoraAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.Livro.EditoraId));
            emprestimoViewModel.ExemplarLivro.Livro.Classificacao = Mapper.Map<Classificacao, ClassificacaoViewModel>(_classificacaoAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.Livro.ClassificacaoId));
            emprestimoViewModel.ExemplarLivro.Livro.Localizacao = Mapper.Map<Localizacao, LocalizacaoViewModel>(_localizacaoAppServico.ObterPorId(emprestimoViewModel.ExemplarLivro.Livro.LocalizacaoId));
        }
    }
}