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
    public interface ILogradouroAbstractRepository
    {
        Task<ICollection<Logradouro>> GetListLogradouro(Expression<Func<Logradouro, bool>> filter = null);

        Task<Logradouro> GetLogradouro(Expression<Func<Logradouro, bool>> filter = null);
        //DadosPessoais AddDadosPessoais(DadosPessoais entity);
        //Task AddAsync(DadosPessoais entity);

    }
}
