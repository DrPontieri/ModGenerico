using Data.Repositories.Abstractions;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net.Mime;

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

        // GET: api/Pessoas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<PostPessoaDto>>> GetPessoasList()
        {
            var pessoasList = await _pessoaabstractrepository.ObterPessoas();

            if (pessoasList == null)
                return NotFound();

            var listPessoaDto = new List<PostPessoaDto>();

            foreach (var pessoa in pessoasList)
            {
                pessoa.DadosPessoais = _dadospessoaisbstractrepository.GetDadosPessoais(c => c.PessoaId == pessoa.Id).ConfigureAwait(false).GetAwaiter().GetResult();
                pessoa.Logradouro = _logradouroabstractrepository.GetLogradouro(c => c.PessoaId == pessoa.Id).ConfigureAwait(false).GetAwaiter().GetResult();
                pessoa.PaymentDetail = _paymentDetailAbstractRepository.GetPaymentDetail(c => c.PessoaId == pessoa.Id).ConfigureAwait(false).GetAwaiter().GetResult();

                var PessoaDto = new PessoaMapper().toDto(pessoa);

                //var DadosPessoaisDto = new PostDadosPessoaisDto
                //{
                //    PessoaID = pessoa.Id,
                //    dtNascimento = pessoa.DadosPessoais.DtNascimento.ToShortDateString(),
                //    nome = pessoa.DadosPessoais.Nome,
                //    email = pessoa.DadosPessoais.Email,
                //    pais = pessoa.DadosPessoais.Pais
                //};

                listPessoaDto.Add(PessoaDto);
            }

            return listPessoaDto.OrderBy(c => c.Id).ToList();
            //return pessoasList.OrderBy(c => c.Id).ToList();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PessoaMapper>> GetPessoasId(int id)
        {
            var pessoa = await _pessoaabstractrepository.GetPessoasId(id);

            if (pessoa == null)
                return NotFound();

            pessoa.DadosPessoais = await _dadospessoaisbstractrepository.GetDadosPessoais(c => c.PessoaId == id);

            pessoa.Logradouro = await _logradouroabstractrepository.GetLogradouro(c => c.PessoaId == id);

            pessoa.PaymentDetail = await _paymentDetailAbstractRepository.GetPaymentDetail(c => c.PessoaId == id);

            var pessoadto = new PessoaMapper().toDto(pessoa);
            //return CreatedAtAction("GetPessoasId", new { id = pessoa.Id }, pessoa);
            return Ok(pessoadto);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Route("PessoasEndpoint")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pessoa>> PostPessoa(PostPessoaDto request)
        {
            if (request.Id != 0)
                return BadRequest();

            Pessoa PessoaOK = new Pessoa();
            //var NewPessoa = new Pessoa
            //{
            //    DataCadastro = Convert.ToDateTime(DateTime.Now),
            //    DadosPessoais = new DadosPessoais
            //    {
            //        Nome = request.nome,
            //        Email = request.email,
            //        Pais = request.pais,
            //        DtNascimento = Convert.ToDateTime(Convert.ToDateTime(request.dtNascimento).ToShortDateString())
            //    },
            //    Logradouro = new Logradouro
            //    {
            //        Cidade = request.cidade,
            //        Estado = request.estado,
            //        Bairro = request.bairro,
            //        Cep = request.cep,
            //        Complemento = request.complemento,
            //        Numero = request.numero,
            //        Endereco = request.endereco
            //    },
            //    PaymentDetail = new PaymentDetail
            //    {
            //        CardOwnerName = request.cardownername,
            //        CardNumber = request.cardnumber,
            //        ExpirationDate = request.expirationdate,
            //        SecurityCode = request.securitycode
            //    }
            //};

            var PessoaEntity = new PessoaMapper().toEntity(request);

            PessoaOK = await _pessoaabstractrepository.AddPessoaAsync(PessoaEntity);

            return CreatedAtAction("GetPessoasId", new { id = PessoaOK.Id }, PessoaOK);
        }
    }
}
