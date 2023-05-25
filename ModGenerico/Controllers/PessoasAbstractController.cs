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

namespace ModGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasAbstractController : ControllerBase
    {
        private readonly IPessoaAbstractRepository _pessoaabstractrepository;
         
        public PessoasAbstractController(IPessoaAbstractRepository pessoaabstractrepository)
        {
            pessoaabstractrepository = _pessoaabstractrepository;
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            var ObjPessoa = new Pessoa(DateTime.Now);
            await _pessoaabstractrepository.AddAsync(ObjPessoa);
            return Ok(ObjPessoa);
        }
    }
}
