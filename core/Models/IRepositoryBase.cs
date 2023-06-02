using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<ICollection<TEntity>> Obter(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> ObterPorIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task DeletarAsync(TEntity entity);
        Task Atualizar(TEntity entity);
    }
}
