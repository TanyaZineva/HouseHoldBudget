using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data.Configuration
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(CreateCurrencies());
        }

        private List<Currency> CreateCurrencies()
        {
            List<Currency> currencies = new List<Currency>()
            {
                new Currency()
                {
                    Id=1,
                    CurrencyName= "BGN",
                    ExchangeRate=0
                },

                new Currency()
                {
                    Id=2,
                    CurrencyName= "EUR",
                    ExchangeRate=1.96
                },
                new Currency()
                {
                    Id=3,
                    CurrencyName= "USD",
                    ExchangeRate=1.85
                },
                 new Currency()
                {
                    Id=4,
                    CurrencyName= "GBP",
                    ExchangeRate=2.28
                }

            };

            return currencies;
        }
    }
}
