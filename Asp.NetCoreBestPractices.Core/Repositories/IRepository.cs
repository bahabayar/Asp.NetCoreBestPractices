using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.Core.Repositories
{
   public interface IRepository<TEntity> where TEntity : class //Vermiş olduğum her neyse class olmak zorunda olsun
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity,bool>> predicate);// Burda expression alduığın için yukarıdaki getbyId den 
        // farkı category.singleordefault dedğim zaman(x=>x.name="Kalem") dediğimiz zaman
        //id yerine name ile dönebiliyo
        Task AddAsync(TEntity entity);
        Task AddRangeASync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
