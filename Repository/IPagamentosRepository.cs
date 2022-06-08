using EstacionamentoDotnet6.Models;

namespace EstacionamentoDotnet6.Repository
{
    public interface IPagamentosRepository
    {
        Pagamento GetPagamentos(int id);
        IEnumerable<Pagamento> GetPagamentos();
        Pagamento AddPagamentos(Pagamento pagamentos);
        Pagamento UpdatePagamentos(Pagamento pagamentos);
        Pagamento DeletePagamentos(int id);

    }
}