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

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
            //return CreatedAtAction("ObterPesssoa", new { id = pessoa.Id }, pessoa);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PostPessoaDto request)
        {
            Pessoa PessoaOK = new Pessoa();

            if (request.Id == 0)
            {
                var NewPessoa = new Pessoa();
                NewPessoa.DataCadastro = DateTime.Now;

                PessoaOK = await _pessoaabstractrepository.AddPessoaAsync(NewPessoa);
            }

            PostDadosPessoaisDto Dados = new PostDadosPessoaisDto();
            Dados.nome = request.nome;
            Dados.pais = request.pais;
            Dados.email = request.email;
            Dados.dtNacimento = request.dtNacimento;
            Dados.PessoaID = PessoaOK.Id;

            return CreatedAtAction("CreateDadosPessoais", PessoaOK, Dados);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("CreateDP")]
        public async Task<ActionResult<Pessoa>> CreateDadosPessoais(PostDadosPessoaisDto request)
        {
            Pessoa PessoaOK = new Pessoa();

            if (request.PessoaID == 0)
            {
                var NewPessoa = new Pessoa();
                NewPessoa.DataCadastro = DateTime.Now;

                PessoaOK = await _pessoaabstractrepository.AddPessoaAsync(NewPessoa);
            }

            return CreatedAtAction("GetPessoasId", new { id = PessoaOK.Id }, PessoaOK);


            //pessoa.DadosPessoais = new DadosPessoais("Danel", "email@email.com.br", "Brasil", pessoaId, DateTime.Now);
        }
    }
}
