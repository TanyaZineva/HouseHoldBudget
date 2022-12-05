using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class UserBudgetInitial
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        
        public int BudgetInitialId { get; set; }

        [ForeignKey(nameof(BudgetInitialId))]
        public BudgetInitial BudgetInitial { get; set; } = null!;


    }
}
