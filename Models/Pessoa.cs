namespace EstacionamentoDotnet6.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}