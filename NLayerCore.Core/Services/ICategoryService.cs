using NLayerCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Core.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Special methods without db 
    }
}
