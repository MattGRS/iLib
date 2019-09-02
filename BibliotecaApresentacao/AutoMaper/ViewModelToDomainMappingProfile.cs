using AutoMapper;
using BibliotecaApresentacao.ViewModels;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaApresentacao.AutoMaper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AssuntoViewModel, Assunto>();
            CreateMap<AutorViewModel, Autor>();
            CreateMap<ClassificacaoViewModel, Classificacao>();
            CreateMap<DadosLoginViewModel, DadosLogin>();
            CreateMap<EditoraViewModel, Editora>();
            CreateMap<EmprestimoViewModel, Emprestimo>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<ExemplarLivroViewModel, ExemplarLivro>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<LocalizacaoViewModel, Localizacao>();
            CreateMap<MunicipioViewModel, Municipio>();
            CreateMap<PaisViewModel, Pais>();
            CreateMap<PessoaViewModel, Pessoa>();
        }

    }
}