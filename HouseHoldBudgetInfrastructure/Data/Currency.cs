using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Infrastructure.Data
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CurrencyName { get; set; } = null!;

        [Required]
        public double ExchangeRate { get; set; }
    }
}
