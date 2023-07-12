using Data.Repositories.Abstractions;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using NuGet.Protocol;
using System.Net;
using System.Net.Mime;

namespace ModGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasAbstractController : ControllerBase
    {
        private readonly IPessoaAbstractRepository _pessoaabstractrepository;


        public PessoasAbstractController(
            IPessoaAbstractRepository pessoaabstractrepository)
        {
            _pessoaabstractrepository = pessoaabstractrepository;
        }

        // GET: api/Pessoas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<PostPessoaDto>>> GetPessoasList()
        {
            var pessoasList = await _pessoaabstractrepository.ObterPessoasAsync();


            if (pessoasList == null)
                return NotFound();

            var listPessoaDto = new List<PostPessoaDto>();

            foreach (Pessoa pessoa in pessoasList)
            {
                var PessoaDto = new PessoaMapper().toDto(pessoa);

                listPessoaDto.Add(PessoaDto);
            }

            return listPessoaDto.OrderByDescending(c => c.Id).ToList();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostPessoaDto>> GetPessoasId(int id)
        {
            var pessoa = await _pessoaabstractrepository.ObterPorIdAsync(id);

            if (pessoa == null)
                return NotFound();

            var pessoadto = new PessoaMapper().toDto(pessoa);
            //return CreatedAtAction("GetPessoasId", new { id = pessoa.Id }, pessoa);
            return Ok(pessoadto);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Route("PessoasEndpoint")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Pessoa))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pessoa>> PostPessoa(PostPessoaDto request)
        {
            if (request.Id != 0 && request.DtCadastro != "")
                return BadRequest();

            var PessoaEntity = new PessoaMapper().toEntity(request);
            
            Pessoa PessoaOK = new Pessoa();
            
            PessoaOK = await _pessoaabstractrepository.AddPessoaAsync(PessoaEntity);

            return Ok(PessoaOK);
        }

        [HttpPut]
        public async Task<ActionResult<PostPessoaDto>> UpdatePessoa(PostPessoaDto pessoa)
        {
            var pessoaEntity = new PessoaMapper().toEntity(pessoa);

            var pessoaEntityUpdate = await _pessoaabstractrepository.UpdatePessoa(pessoaEntity);

            var pessoaDtoReturn = new PessoaMapper().toDto(pessoaEntityUpdate);

            return Ok(pessoaDtoReturn);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePessoa(int id)
        {
            var FindPessoa = await _pessoaabstractrepository.ObterPorIdAsync(id);
           
            if (FindPessoa == null)
                return NotFound();

            await _pessoaabstractrepository.DeletePessoa(FindPessoa);

            return Ok(HttpStatusCode.OK);
        }
    }
}
