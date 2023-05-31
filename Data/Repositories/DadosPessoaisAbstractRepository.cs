using core.Models;
using Data.Context;
using Data.Repositories.Abstractions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(DadosPessoais entity)
        {
            await _dadospessoaisRepository.AddAsync(entity);
        }
    }
}
