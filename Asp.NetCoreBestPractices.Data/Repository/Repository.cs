using Asp.NetCoreBestPractices.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class

    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public Repository(DbContext context)
        {
            _context = context;//Veritabanına ulaşıyoruz
            _dbset = context.Set<TEntity>();//Tablolara ulaşıyoruz

        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeASync(IEnumerable<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.SingleOrDefaultAsync(predicate);//Delegeler metotları işaret eder nasıl bir metot yapısına sahip olucağını söyler
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;//Entity framework gelen bu entitnin durumunu modified görünce bunu entity'e yansıtır
            //Çok satırlı  yerlerde bun kullanmanız mantıklı
            return entity;
            //entity.na
        }
    }
}
