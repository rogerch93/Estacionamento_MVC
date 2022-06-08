namespace EstacionamentoDotnet6.Models
{
    public class Carro
    {
        public Carro(int carroId, string nomeCarro, string modelo, string marca, string placa, Pessoa pessoas)
        {
            CarroId = carroId;
            NomeCarro = nomeCarro;
            Modelo = modelo;
            Marca = marca;
            Placa = placa;
            Pessoas = pessoas;
        }

        public int CarroId { get; set; }
        public string NomeCarro { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public Pessoa Pessoas { get; set; }
    }
}