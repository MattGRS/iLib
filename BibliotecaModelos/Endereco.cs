namespace BibliotecaModelos
{
    public class Endereco
    {
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public Municipio Municipio { get; private set; }
    }
}