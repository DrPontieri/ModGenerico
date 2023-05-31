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
        private readonly IRepositoryBase<DadosPessoais> _dadospessoaisRepository;
        public PessoaAbstractRepository(IRepositoryBase<Pessoa> pessoaRepository, IRepositoryBase<DadosPessoais> dadospessoaisRepository)
        {
            _pessoaRepository = pessoaRepository;
            _dadospessoaisRepository = dadospessoaisRepository;
        }
        
        public async Task AddPessoaAsync(Pessoa entity)
        {
            await _pessoaRepository.AddAsync(entity);

        }

        public async Task AddDadosPessoaisAsync(DadosPessoais entity)
        {
            await _dadospessoaisRepository.AddAsync(entity);
        }

        public async Task<Pessoa> GetPessoasId(int id)
        {
            return await _pessoaRepository.ObterPorIdAsync(id);
        }

        public async Task<ICollection<Pessoa>> ObterPessoas()
        {
            return await _pessoaRepository.Obter();
        }
    }
}
