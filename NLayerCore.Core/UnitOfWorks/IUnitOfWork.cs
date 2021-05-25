using NLayerCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Core.UnitOfWorks
{
    interface IUnitOfWork
    {
        IProductRepository Produtcs { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsync();

        void Commit();
    }
}
