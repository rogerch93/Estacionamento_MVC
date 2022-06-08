using EstacionamentoDotnet6.Models;

namespace EstacionamentoDotnet6.Repository
{
    public interface ICarroRepository
    {
        Carro GetCarro(int id);
        IEnumerable<Carro> GetCarros();
        Carro AddCarro(Carro carro);
        Carro UpdateCarro(Carro carro);
        Carro DeleteCarro(int id);
    }
}