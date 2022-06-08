namespace EstacionamentoDotnet6.Models
{
    public class Estadia
    {
        public Estadia(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public int Id { get; set; }
        public int NumVaga { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        Pessoa Pessoa { get; set; }
      
    }
}