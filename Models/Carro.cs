namespace EstacionamentoDotnet6.Models
{
    public class Carro
    {
     

        public int CarroId { get; set; }
        public string NomeCarro { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }

        public int PessoasId { get; set; }
        public Pessoa Pessoas { get; set; }

    }
}