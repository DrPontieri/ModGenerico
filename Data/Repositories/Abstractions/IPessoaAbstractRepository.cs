using core.Models;
using Domain;
using Domain.Dto;
using System.Linq.Expressions;

namespace Data.Repositories.Abstractions
{
    public interface IPessoaAbstractRepository
    {
        Task<ICollection<Pessoa>> ObterPessoasAsync();

        Task<Pessoa> ObterPorIdAsync(int id);

        Task<Pessoa> AddPessoaAsync(Pessoa entity);

        Task<Pessoa> UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);

    }
}
