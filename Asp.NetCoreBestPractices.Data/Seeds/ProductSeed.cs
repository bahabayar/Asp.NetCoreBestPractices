using Asp.NetCoreBestPractices.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCoreBestPractices.Data.Seeds
{
    class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 120, CategoryId = _ids[0] },
                 new Product { Id = 2, Name = "Kurşun Kalem", Price = 20.50m, Stock = 250, CategoryId = _ids[0] },
                 new Product { Id = 3, Name = "Tükenmez Kalem", Price = 500m, Stock = 300, CategoryId = _ids[0] },
                 new Product { Id = 4, Name = "Küçük Boy Defter", Price = 200m, Stock = 100, CategoryId = _ids[1] },
                 new Product { Id = 5, Name = "Orta Boy Defter", Price = 200m, Stock = 100, CategoryId = _ids[1] },
                 new Product { Id = 6, Name = "Büyük Boy Defter", Price = 200m, Stock = 100, CategoryId = _ids[1] }
                );
        }
    }
}
