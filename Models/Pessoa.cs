namespace EstacionamentoDotnet6.Models
{
    public class Pessoa
    {

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public virtual Carro Carro { get; set; }
    }
}