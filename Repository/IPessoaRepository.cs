using EstacionamentoDotnet6.Models;

namespace EstacionamentoDotnet6.Repository
{
    public interface IPessoaRepository
    {
        Pessoa GetPessoa(int id);
        IEnumerable<Pessoa> GetPessoas();
        Pessoa AddPessoa(Pessoa pessoa);
        Pessoa UpdatePessoa(Pessoa pessoa);
        Pessoa DeletePessoa(int id);
    }
}