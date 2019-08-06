using BibliotecaDados.EntidadesConfig;
using BibliotecaDominio;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.ObjetosValor;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDados.Contexto
{
    class BibliotecaContext : DbContext
    {
        public DbSet<Assunto> Assuntos { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Classificacao> Classificacoes { get; set; }

        public DbSet<Editora> Editoras { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<ExemplarLivro> Exemplares { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        public BibliotecaContext()
        {

        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CPF>().HasKey("Cpf");
            //modelBuilder.ApplyConfiguration(new AssuntoConfig());
            //modelBuilder.ApplyConfiguration(new AssuntoConfig());
            //modelBuilder.ApplyConfiguration(new ClassificacaoConfig());
            //modelBuilder.ApplyConfiguration(new CpfConfig());
            //modelBuilder.ApplyConfiguration(new EditoraConfig());
            ////modelBuilder.ApplyConfiguration(new EnderecoConfig());
            //modelBuilder.ApplyConfiguration(new EstadosConfig());
            ////modelBuilder.ApplyConfiguration(new ExemplarConfig());
            //modelBuilder.ApplyConfiguration(new LivroConfig());
            //modelBuilder.ApplyConfiguration(new LocalizacaoConfig());
            //modelBuilder.ApplyConfiguration(new MunicipioConfig());
            //modelBuilder.ApplyConfiguration(new PaisConfig());
            //modelBuilder.ApplyConfiguration(new PessoaConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BibliotecaDB;Trusted_Connection=true;");
            }
        }
    }
}
