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
    public class LogradouroAbstractRepository : ILogradouroAbstractRepository
    {
        private readonly IRepositoryBase<Logradouro> _logradouroRepository;

        public LogradouroAbstractRepository(IRepositoryBase<Logradouro> logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<ICollection<Logradouro>> GetListLogradouro(Expression<Func<Logradouro, bool>> filter = null)
        {
            return await _logradouroRepository.ObterList(filter);
        }

        public async Task<Logradouro> GetLogradouro(Expression<Func<Logradouro, bool>> filter = null)
        {
            return await _logradouroRepository.ObterObj(filter);
        }
    }
}
