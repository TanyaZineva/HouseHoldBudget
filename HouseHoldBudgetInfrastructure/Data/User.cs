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
        public List<UserBudgetInitial> UserBudgetInitials { get; set; } = new List<UserBudgetInitial>();
        public List<UserHouseHold> UserHouseHolds { get; set; } = new List<UserHouseHold>();
    }
}
