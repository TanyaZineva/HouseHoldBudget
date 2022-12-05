using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class BudgetInitial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; } = null!;

        [Required]
        public int TypeOfAccountId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeOfAccountId))]
        public TypeOfAccount TypeOfAccount { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string AdditionalInformation { get; set; } = null!;

        public List<UserBudgetInitial> UserBudgetInitials { get; set; } = new List<UserBudgetInitial>();
    }
}
