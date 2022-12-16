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
    public class MyBudgetViewModel
    {
        public int Id { get; set; }
        public string TypeOfAccount { get; set; } = null!;

        public string Category { get; set; }= null!;

        public string Currency { get; set; } = null!;

        public decimal Amount { get; set; }
        public decimal AmountInBgn { get; set; }
        public DateTime Date { get; set; }
        public string? AdditionalInformation { get; set; } = null!;
    }
}
