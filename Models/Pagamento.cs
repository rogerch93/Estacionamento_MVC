using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamentoDotnet6.Models
{
    public class Pagamento
    {
        

        public int Id { get; set; }
        
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Total { get; set; }
        public bool Pago { get; set; }

        public int PessoasId { get; set; }
        Pessoa Pessoas{ get; set; }
    }
}