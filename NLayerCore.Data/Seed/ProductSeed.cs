using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Data.Seed
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIds;

        public ProductSeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pilot Kalem",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _categoryIds[0]
                },
                new Product
                {
                    Id = 2,
                    Name = "Kurşun Kalem",
                    Price = 40,
                    Stock = 200,
                    CategoryId = _categoryIds[0]
                },
                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 500,
                    Stock = 300,
                    CategoryId = _categoryIds[0]
                },
                new Product
                {
                    Id = 4,
                    Name = "Küçük Boy Defter",
                    Price = 100,
                    Stock = 200,
                    CategoryId = _categoryIds[1]
                },
                new Product
                {
                    Id = 5,
                    Name = "Orta Boy Defter",
                    Price = 150,
                    Stock = 400,
                    CategoryId = _categoryIds[1]
                },
                new Product
                {
                    Id = 6,
                    Name = "Büyük Boy Defter",
                    Price = 200,
                    Stock = 300,
                    CategoryId = _categoryIds[1]
                });
        }
    }
}
