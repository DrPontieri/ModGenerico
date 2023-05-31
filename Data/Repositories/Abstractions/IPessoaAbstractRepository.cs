using core.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstractions
{
    public interface IPessoaAbstractRepository
    {
        Task AddPessoaAsync(Pessoa entity);

        Task AddDadosPessoaisAsync(DadosPessoais entity);

        Task<Pessoa> GetPessoasId(int id);

        Task<ICollection<Pessoa>> ObterPessoas();

    }
}
