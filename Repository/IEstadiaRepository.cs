using EstacionamentoDotnet6.Models;

namespace EstacionamentoDotnet6.Repository
{
    public interface IEstadiaRepository
    {
        Estadia GetEstadia(int id);
        IEnumerable<Estadia> GetEstadias();
        Estadia AddEstadia(Estadia estadia);
        Estadia UpdateEstadia(Estadia estadia);
        Estadia DeleteEstadia(int id);

    }
}