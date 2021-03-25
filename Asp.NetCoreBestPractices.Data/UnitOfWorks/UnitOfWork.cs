using Asp.NetCoreBestPractices.Core.Repositories;
using Asp.NetCoreBestPractices.Core.UnitOfWork;
using Asp.NetCoreBestPractices.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.Data.UnitOfWorks
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()//saveChanges
        {
           _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
