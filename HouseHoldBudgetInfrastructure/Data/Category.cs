using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [StringLength(500, MinimumLength = 5)]
        public string? Detail { get; set; }

        [Required]
        [StringLength(2000)]
        public string ImageUrl { get; set; } = null!;
    }
}
