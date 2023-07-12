using core.Models;
using Data.Context;
using Data.Repositories.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PaymentDetailAbstractRepository : IPaymentDetailAbstractRepository
    {
        private readonly IRepositoryBase<PaymentDetail> _paymentdetailrepository;

        public PaymentDetailAbstractRepository(IRepositoryBase<PaymentDetail> paymentdetailRepository)
        {
            _paymentdetailrepository = paymentdetailRepository;
        }

        public async Task<ICollection<PaymentDetail>> GetListPaymentDetail(Expression<Func<PaymentDetail, bool>> filter = null)
        {
            return await _paymentdetailrepository.ObterListAsync(filter);
        }

        public async Task<PaymentDetail> GetPaymentDetail(Expression<Func<PaymentDetail, bool>> filter = null)
        {
            return await _paymentdetailrepository.ObterObj(filter);
        }
    }
}
