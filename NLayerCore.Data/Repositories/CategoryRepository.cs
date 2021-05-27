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
    class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _appContext
        {
            get { return _context as ApplicationDbContext; }
        }
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
