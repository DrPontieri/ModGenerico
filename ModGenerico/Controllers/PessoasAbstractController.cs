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

namespace ModGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasAbstractController : ControllerBase
    {
        private readonly IPessoaAbstractRepository _pessoaabstractrepository;
        private readonly IDadosPessoaisAbstractRepository _dadospessoaisbstractrepository;


        public PessoasAbstractController(IPessoaAbstractRepository pessoaabstractrepository, IDadosPessoaisAbstractRepository dadospessoaisbstractrepository)
        {
            _pessoaabstractrepository = pessoaabstractrepository;
            _dadospessoaisbstractrepository = dadospessoaisbstractrepository;   
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoasId(int id)
        {
             
            var pessoa = await _pessoaabstractrepository.GetPessoasId(id);

            pessoa.DadosPessoais = await _dadospessoaisbstractrepository.GetDadosPessoais(c => c.PessoaId == pessoa.Id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetPessoasId", new { id = pessoa.Id }, pessoa);
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
                    DataCadastro = DateTime.Now,
                    DadosPessoais = new DadosPessoais
                    {
                        Nome = request.nome,
                        Email = request.email,
                        Pais = request.pais,
                        DtNascimento = request.dtNascimento                        
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
