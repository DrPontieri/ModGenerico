using core.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Abstractions
{
    public interface IPaymentDetailAbstractRepository
    {
        Task<ICollection<PaymentDetail>> GetListPaymentDetail(Expression<Func<PaymentDetail, bool>> filter = null);

        Task<PaymentDetail> GetPaymentDetail(Expression<Func<PaymentDetail, bool>> filter = null);
        //DadosPessoais AddDadosPessoais(DadosPessoais entity);
        //Task AddAsync(DadosPessoais entity);

    }
}
