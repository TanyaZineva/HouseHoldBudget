using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class TypeOfAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; } = null!;

    }
}
