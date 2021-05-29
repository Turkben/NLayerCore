using Microsoft.EntityFrameworkCore;
using NLayerCore.Core.Models;
using NLayerCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private ApplicationDbContext _appContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }

        


    }
}
