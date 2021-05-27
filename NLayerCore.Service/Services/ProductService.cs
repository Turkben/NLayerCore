using NLayerCore.Core.Models;
using NLayerCore.Core.Repositories;
using NLayerCore.Core.Services;
using NLayerCore.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Service.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
