using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class UserHouseHold
    {
        public int HouseHoldId { get; set; }

        [ForeignKey(nameof(HouseHoldId))]
        public HouseHold HouseHold { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
