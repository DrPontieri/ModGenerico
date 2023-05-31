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
        private IPessoaAbstractRepository _pessoaabstractrepository;


        public PessoasAbstractController(IPessoaAbstractRepository pessoaabstractrepository)
        {

            pessoaabstractrepository = _pessoaabstractrepository;

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

            return CreatedAtAction("ObterPesssoa", new { id = pessoa.Id }, pessoa);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PostDadosPessoaisDto request)
        {
            var pessoa = await _pessoaabstractrepository.GetPessoasId(request.PessoaID);
            if(pessoa == null)
            {
                pessoa = new Pessoa(DateTime.Now);
                int PessooaId = _pessoaabstractrepository.AddPessoaAsync(pessoa).Id;
            }
            pessoa.LstDadosPessoais.Add(new DadosPessoais("Danel", "email@email.com.br", "Brasil", DateTime.Now));
            pessoa.Id = _pessoaabstractrepository.AddPessoaAsync(pessoa).Id;

            

            //pessoa.DadosPessoais = new DadosPessoais("Danel", "email@email.com.br", "Brasil", pessoaId, DateTime.Now);
                        
            return CreatedAtAction("ObterPesssoa", new { id = pessoa.Id }, pessoa);

        }
    }
}
