using Asp.NetCoreBestPractices.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCoreBestPractices.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] id)
        {
            _ids = id;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category {Id=_ids[0], Name="Kalemler" },
                new Category {Id=_ids[1],Name="Defterler" }
                );
        }
    }
}
