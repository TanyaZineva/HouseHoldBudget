using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class User:IdentityUser
    {
        
        public int HouseHoldId { get; set; }

        [ForeignKey(nameof(HouseHoldId))]
        public HouseHold HouseHold { get; set; } = null!;

        public List<UserBudgetInitial> UserBudgetInitials { get; set; } = new List<UserBudgetInitial>();
    }
}
