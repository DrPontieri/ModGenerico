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
    public class PessoaAbstractRepository : IPessoaAbstractRepository
    {

        private readonly IRepositoryBase<Pessoa> _pessoaRepository;
        public PessoaAbstractRepository(IRepositoryBase<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task AddAsync(Pessoa entity)
        {
            await _pessoaRepository.AddAsync(entity);
        }
    }
}
