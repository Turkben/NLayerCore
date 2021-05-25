using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Core.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        //navigation property
        public ICollection<Product> Products { get; set; }

    }
}
