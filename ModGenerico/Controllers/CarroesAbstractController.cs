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
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ModGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroesAbstractController : ControllerBase
    {
        private readonly ICarroRepository _icarrorepository;

        public CarroesAbstractController(ICarroRepository icarrorepository)
        {
            _icarrorepository = icarrorepository;
        }

        // POST: api/Carroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostAbstractCarro(Carro carro)
        {
            var ObjCarro = new Carro(nome: "Daniel", potencia: 1);
            await _icarrorepository.AddAsync(carro);
            return Ok(ObjCarro);
        }
    }
}
