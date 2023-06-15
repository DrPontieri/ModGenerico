using core.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstractions
{
    public interface IDadosPessoaisAbstractRepository
    {
        Task<ICollection<DadosPessoais>> GetListDadosPessoais(Expression<Func<DadosPessoais, bool>> filter = null);

        Task<DadosPessoais> GetDadosPessoais(Expression<Func<DadosPessoais, bool>> filter = null);
        DadosPessoais AddDadosPessoais(DadosPessoais entity);
        Task AddAsync(DadosPessoais entity);

    }
}
