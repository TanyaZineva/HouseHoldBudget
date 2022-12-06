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
                    ImageUrl="https://mpng.subpng.com/20200228/kzx/transparent-assets-icon-loan-icon-fintech-icon-5e59c31a69f9f5.2406849615829409544341.jpg"
                },
                new Category()
                {
                    Id=2,
                    Name="Transportation",
                    ImageUrl="https://w7.pngwing.com/pngs/359/237/png-transparent-rail-transport-logistics-mode-of-transport-public-transport-beautifully-global-travel-background-material-freight-transport-service-logo.png"
                },
                new Category()
                {
                    Id=3,
                    Name="Food",
                    ImageUrl="https://previews.123rf.com/images/fdsstudio/fdsstudio1905/fdsstudio190500013/122776211-food-icon-on-white-background-cutlery-as-a-symbol-of-food-vector-logo-for-graphic-design-.jpg"
                },
                new Category()
                {
                    Id=4,
                    Name="Utilities",
                    Detail= "Utilities generally include your gas, electricity, water, and sewage bills",
                    ImageUrl="https://as1.ftcdn.net/v2/jpg/04/36/98/62/1000_F_436986282_xPXikgyys8ghwYx1rYJewxKPKHLM7lVv.jpg"
                },
                 new Category()
                {
                    Id=5,
                    Name="Medical & Healthcare",
                    Detail="Medical care, dental appointments",
                    ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSco2fhPOojGcC3duj_oajm6FJyho3ugGP8NhojGwBAyfQs34CBMyud-ALrKcJ_bdxMNj8&usqp=CAU"

                },
                  new Category()
                {
                    Id=6,
                    Name="Clothes and shoes",
                    ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3LZt2J5V_rt89Jj1dsT09dFzfxWlfFaikUQ&usqp=CAU"
                },
                     new Category()
                {
                    Id=7,
                    Name="Hobbies",
                    ImageUrl="https://cdn.iconscout.com/icon/premium/png-256-thumb/hobbies-1651245-1403352.png"
                },
                        new Category()
                {
                    Id=8,
                    Name="Vacation",
                    ImageUrl="https://png.pngtree.com/element_our/png/20180807/pngtree-pinmark-vacation-icon-and-concept-png-image_54653.jpg"
                },
                new Category()
                {
                    Id=9,
                    Name="Restaurants",
                    ImageUrl="https://img.freepik.com/premium-vector/restaurant-icon-concept-with-icon-design_24911-17835.jpg"
                },
                 new Category()
                {
                    Id=10,
                    Name="Home decor and furnishings",
                    ImageUrl="https://images.all-free-download.com/images/graphiclarge/home_decor_background_chair_light_table_flowerpot_icons_6838281.jpg"
                },
                   new Category()
                {
                    Id=11,
                    Name="Saving",
                    ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf4l7pqQ83E-tDbAKZNZEEn8Wi7mt-rBM-1w&usqp=CAU"
                },
                    new Category()
                {
                    Id=12,
                    Name="Investing",
                    ImageUrl="https://cdn-icons-png.flaticon.com/512/4988/4988659.png"
                },
                     new Category()
                {
                    Id=13,
                    Name="Others",
                    ImageUrl="https://i1.sndcdn.com/avatars-000330114611-hkocch-t500x500.jpg"
                },
            };
             
            return categories;
        }
            
    }
}
