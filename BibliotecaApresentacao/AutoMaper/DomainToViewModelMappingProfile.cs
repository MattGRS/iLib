using AutoMapper;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaApresentacao.AutoMaper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Assunto, AssuntoViewModel>();
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Classificacao, ClassificacaoViewModel>();
            CreateMap<DadosLogin, DadosLoginViewModel>();
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Emprestimo, EmprestimoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<ExemplarLivro, ExemplarLivroViewModel>();
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Localizacao, LocalizacaoViewModel>();
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<Pais, PaisViewModel>();
            CreateMap<Pessoa, PessoaViewModel>();
        }

    }
}