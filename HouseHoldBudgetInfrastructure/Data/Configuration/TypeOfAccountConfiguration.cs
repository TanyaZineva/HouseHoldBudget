using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data.Configuration
{
    internal class TypeOfAccountConfiguration : IEntityTypeConfiguration<TypeOfAccount>
    {
        public void Configure(EntityTypeBuilder<TypeOfAccount> builder)
        {
            builder.HasData(CreateTypeOfAccounts());
        }

        private List<TypeOfAccount> CreateTypeOfAccounts()
        {
            List<TypeOfAccount> typeOfAccounts = new List<TypeOfAccount>()
             {
                 new TypeOfAccount()
                 {
                     Id=1,
                     Type= "Income"
                 },
                 new TypeOfAccount()
                 {
                     Id=2,
                     Type= "Expense"
                 }  
             };
            
            return typeOfAccounts;
        }
    }
}
