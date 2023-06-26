using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain;
using Data.Repositories.Abstractions;
using Data.Repositories;
using core.Models;
using NuGet.Protocol;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ModGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasAbstractController : ControllerBase
    {
        private readonly IPessoaAbstractRepository _pessoaabstractrepository;
        private readonly IDadosPessoaisAbstractRepository _dadospessoaisbstractrepository;
        private readonly ILogradouroAbstractRepository _logradouroabstractrepository;
        private readonly IPaymentDetailAbstractRepository _paymentDetailAbstractRepository;


        public PessoasAbstractController(
            IPessoaAbstractRepository pessoaabstractrepository, 
            IDadosPessoaisAbstractRepository dadospessoaisbstractrepository, 
            ILogradouroAbstractRepository logradouroabstractrepository,
            IPaymentDetailAbstractRepository paymentdetailrepository)
        {
            _pessoaabstractrepository = pessoaabstractrepository;
            _dadospessoaisbstractrepository = dadospessoaisbstractrepository;
            _logradouroabstractrepository = logradouroabstractrepository;
            _paymentDetailAbstractRepository = paymentdetailrepository;
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoasId(int id)
        {
            var pessoa = await _pessoaabstractrepository.GetPessoasId(id);

            if (pessoa == null)
                return NotFound();

            pessoa.DadosPessoais = await _dadospessoaisbstractrepository.GetDadosPessoais(c => c.PessoaId == id);

            pessoa.Logradouro = await _logradouroabstractrepository.GetLogradouro(c => c.PessoaId == id);

            pessoa.PaymentDetail = await _paymentDetailAbstractRepository.GetPaymentDetail(c => c.PessoaId == id);

            //return CreatedAtAction("GetPessoasId", new { id = pessoa.Id }, pessoa);
            return Ok(pessoa);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Route("PessoasEndpoint")]
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PostPessoaDto request)
        {
            Pessoa PessoaOK = new Pessoa();

            if (request.Id == 0)
            {
                var NewPessoa = new Pessoa
                {
                    DataCadastro = Convert.ToDateTime(DateTime.Now),
                    DadosPessoais = new DadosPessoais
                    {
                        Nome = request.nome,
                        Email = request.email,
                        Pais = request.pais,
                        DtNascimento = Convert.ToDateTime(request.dtNascimento).ToShortDateString()
                    },
                    Logradouro = new Logradouro 
                    {
                        Cidade = request.cidade,
                        Estado = request.estado,
                        Bairro = request.bairro,
                        Cep = request.cep,
                        Complemento = request.complemento,
                        Numero = request.numero,
                        Endereco = request.endereco
                    },
                    PaymentDetail= new PaymentDetail
                    {
                        CardOwnerName = request.cardownername,
                        CardNumber = request.cardnumber,
                        ExpirationDate = request.expirationdate,
                        SecurityCode = request.securitycode
                    }
                };

                PessoaOK = await _pessoaabstractrepository.AddPessoaAsync(NewPessoa);
            }
            
            return CreatedAtAction("GetPessoasId", new { id = PessoaOK.Id }, PessoaOK);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        //[ActionName("CreateDP")]
        //public Pessoa CreateDadosPessoais(PostDadosPessoaisDto requestDpPessoa)
        //{
        //    returCreateDpOk(requestDpPessoa);
        //}

        //[Route("CreateDpEndpoint")]
        //[HttpPost]
        //public async Task<ActionResult<DadosPessoais>> PostDadosPessoais(PostDadosPessoaisDto requestDpPessoa)
        //{
        //    Pessoa PessoaOK = new Pessoa();
        //    if (requestDpPessoa.PessoaID == 0)
        //    {
        //        var NewPessoa = new Pessoa {
        //            DataCadastro = DateTime.Now,
        //            DadosPessoais = new DadosPessoais
        //            {
        //                Nome = requestDpPessoa.nome,
        //                PessoaId = requestDpPessoa.PessoaID,
        //                Email = requestDpPessoa.email,
        //                Pais = requestDpPessoa.pais,
        //                DtNascimento = requestDpPessoa.dtNascimento
        //            }                
        //    };

        //        PessoaOK =  await _pessoaabstractrepository.AddPessoaAsync(NewPessoa);
        //    }
            
        //        PessoaOK = await _pessoaabstractrepository.GetPessoasId(requestDpPessoa.PessoaID);

                

        //        //var DadosPessoaisCreated = _dadospessoaisbstractrepository.AddDadosPessoais(DpNovo);
        //        //PessoaOK.DadosPessoais = DadosPessoaisCreated;
             

        //    return CreatedAtAction("GetPessoasId", new { id = PessoaOK.Id }, PessoaOK);

        //    //pessoa.DadosPessoais = new DadosPessoais("Danel", "email@email.com.br", "Brasil", pessoaId, DateTime.Now);
        //}
    }
}
