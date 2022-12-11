using HouseHoldBudget.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace HouseHoldBudget.Core.Models.HouseHolds
{
    public class AddViewModel
    {
        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public IEnumerable<HouseHold> HouseHolds { get; set; } = new List<HouseHold>();
    }
}

