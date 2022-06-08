namespace EstacionamentoDotnet6.Models
{
    public class Pagamento
    {
        public Pagamento(Pessoa pessoas)
        {
            Pessoas = pessoas;
        }

        public int Id { get; set; }
        public Decimal Total { get; set; }
        public bool Pago { get; set; }
        Pessoa Pessoas{ get; set; }
    }
}