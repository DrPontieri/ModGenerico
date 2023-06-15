using core.Models;
using Data.Context;
using Data.Repositories.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DadosPessoaisAbstractRepository : IDadosPessoaisAbstractRepository
    {
        private readonly IRepositoryBase<DadosPessoais> _dadospessoaisRepository;

        public DadosPessoaisAbstractRepository(IRepositoryBase<DadosPessoais> dadospessoaisRepository)
        {
            _dadospessoaisRepository = dadospessoaisRepository;
        }

        //public async Task<DadosPessoais> GetDadosPessoais(Expression<Func<DadosPessoais, bool>> filter = null)
        //{

        //    return await _dadospessoaisRepository.Obter(id);
        //}

        public async Task AddAsync(DadosPessoais entity)
        {
            await _dadospessoaisRepository.AddAsync(entity);
        }

        public DadosPessoais AddDadosPessoais(DadosPessoais entity)
        {
            return _dadospessoaisRepository.AddSync(entity);   
        }

        public async Task<DadosPessoais> GetDadosPessoais(Expression<Func<DadosPessoais, bool>> filter = null)
        {
            return await _dadospessoaisRepository.ObterObj(filter);
        }

        public async Task<ICollection<DadosPessoais>> GetListDadosPessoais(Expression<Func<DadosPessoais, bool>> filter = null)
        {
            return await _dadospessoaisRepository.ObterList(filter);
        }
    }
}
