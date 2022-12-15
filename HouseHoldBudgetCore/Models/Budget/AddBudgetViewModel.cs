using HouseHoldBudget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace HouseHoldBudget.Core.Models.Budget
{
    public class AddBudgetViewModel
    {
        [Required]
        public int TypeOfAccountId { get; set; }

        [Required]
        public IEnumerable<TypeOfAccount> TypeOfAccounts { get; set; } = new List<TypeOfAccount>();

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public IEnumerable<Currency> Currencies { get; set; } = new List<Currency>();

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Amount { get; set; } 

        [Required]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string AdditionalInformation { get; set; } = null!;
    }
}
