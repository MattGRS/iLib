namespace BibliotecaModelos
{
    public class Endereco
    {
        //Confirmar propriedade IdPessoa                          ´
        public int IdPessoa { get; set; }
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public Municipio Municipio { get; private set; }
    }
}