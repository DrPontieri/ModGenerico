using core.Models;
using Data.Context;
using Data.Repositories.Abstractions;
using Domain;
using Domain.Dto;
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
        private readonly IDadosPessoaisAbstractRepository _dadospessoaisAbstractRepository;
        private readonly ILogradouroAbstractRepository _logradouroAbstractRepository;
        private readonly IPaymentDetailAbstractRepository _paymentdetailAbstractRepository;
        public PessoaAbstractRepository(IRepositoryBase<Pessoa> pessoaRepository, IDadosPessoaisAbstractRepository dadospessoaisAbstractRepository, ILogradouroAbstractRepository logradouroAbstractRepository, IPaymentDetailAbstractRepository paymentdetailAbstractRepository)
        {
            _pessoaRepository = pessoaRepository;
            _dadospessoaisAbstractRepository = dadospessoaisAbstractRepository;
            _logradouroAbstractRepository = logradouroAbstractRepository;
            _paymentdetailAbstractRepository = paymentdetailAbstractRepository;
        }

        public async Task<Pessoa> AddPessoaAsync(Pessoa entity)
        {
            var pessoa = await _pessoaRepository.AddAsync(entity);

            return pessoa;
        }

        public async Task<Pessoa> ObterPorIdAsync(int id)
        {
            var pessoa = await _pessoaRepository.ObterPorIdAsync(id);

            //if (pessoa == null)
            //    return NotFound();

            int idpessoa = pessoa.Id;

            pessoa.DadosPessoais = await _dadospessoaisAbstractRepository.GetDadosPessoais(c => c.PessoaId == idpessoa);

            pessoa.Logradouro = await _logradouroAbstractRepository.GetLogradouro(c => c.PessoaId == idpessoa);

            pessoa.PaymentDetail = await _paymentdetailAbstractRepository.GetPaymentDetail(c => c.PessoaId == idpessoa);
            return pessoa;
        }

        public async Task<ICollection<Pessoa>> ObterPessoasAsync()
        {
            var pessoaList = await _pessoaRepository.ObterListAsync();
            //if (pessoa == null)
            //    return NotFound();
            var ListPessoaCompleta = new List<Pessoa>();

            foreach (var pessoa in pessoaList)
            {
                int idpessoa = pessoa.Id;

                pessoa.DadosPessoais = await _dadospessoaisAbstractRepository.GetDadosPessoais(c => c.PessoaId == idpessoa);

                pessoa.Logradouro = await _logradouroAbstractRepository.GetLogradouro(c => c.PessoaId == idpessoa);

                pessoa.PaymentDetail = await _paymentdetailAbstractRepository.GetPaymentDetail(c => c.PessoaId == idpessoa);

                ListPessoaCompleta.Add(pessoa);
            }

            return ListPessoaCompleta;
        }

        public async Task<Pessoa> UpdatePessoa(Pessoa pessoa)
        {
            return await _pessoaRepository.Atualizar(pessoa);
        }

        public async Task DeletePessoa(Pessoa pessoa)
        {
            await _pessoaRepository.DeletarAsync(pessoa);
        }

        
    }
}
