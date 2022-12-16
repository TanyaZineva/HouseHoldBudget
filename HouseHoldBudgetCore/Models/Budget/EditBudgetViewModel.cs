using HouseHoldBudget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Models.Budget
{
    public class EditBudgetViewModel
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
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime Date { get; set; }


        [StringLength(100, MinimumLength = 5)]
        public string? AdditionalInformation { get; set; } = null!;
    }
}
