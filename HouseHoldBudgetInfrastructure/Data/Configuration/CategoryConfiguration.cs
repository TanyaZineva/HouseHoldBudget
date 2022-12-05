using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HouseHoldBudget.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id=1,
                    Name="Loans/Mortgage",
                },
                new Category()
                {
                    Id=2,
                    Name="Transportation",
                },
                new Category()
                {
                    Id=3,
                    Name="Food",
                },
                new Category()
                {
                    Id=4,
                    Name="Utilities",
                    Detail= "Utilities generally include your gas, electricity, water, and sewage bills",
                },
                 new Category()
                {
                    Id=5,
                    Name="Medical & Healthcare",
                    Detail="Medical care, dental appointments",

                },
                  new Category()
                {
                    Id=6,
                    Name="Clothes and shoes",
                },
                     new Category()
                {
                    Id=7,
                    Name="Hobbies",
                },
                        new Category()
                {
                    Id=8,
                    Name="Vacation",
                },
                new Category()
                {
                    Id=9,
                    Name="Restaurants",
                },
                 new Category()
                {
                    Id=10,
                    Name="Home decor and furnishings",
                },
                   new Category()
                {
                    Id=11,
                    Name="Saving",    
                },
                    new Category()
                {
                    Id=12,
                    Name="Investing",
                },
                     new Category()
                {
                    Id=13,
                    Name="Others",
                },
            };
             
            return categories;
        }
            
    }
}
