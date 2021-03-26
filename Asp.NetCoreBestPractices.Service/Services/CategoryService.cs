using Asp.NetCoreBestPractices.Core.Models;
using Asp.NetCoreBestPractices.Core.Repositories;
using Asp.NetCoreBestPractices.Core.Services;
using Asp.NetCoreBestPractices.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
