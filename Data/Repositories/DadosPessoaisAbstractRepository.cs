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
    public class DadosPessoaisAbstractRepository : RepositoryBase<DadosPessoais>, IDadosPessoaisAbstractRepository
    {
        public DadosPessoaisAbstractRepository(AppDbContext appContext) : base(appContext)
        {

        }
    }
}
