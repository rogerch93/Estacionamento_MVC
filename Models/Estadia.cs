namespace EstacionamentoDotnet6.Models
{
    public class Estadia
    {
       

        public int Id { get; set; }
        public int NumVaga { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }

        public int PessoaId { get; set; }
        Pessoa Pessoa { get; set; }
      
    }
}