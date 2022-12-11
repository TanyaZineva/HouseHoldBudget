using HouseHoldBudget.Core.Models.HouseHolds;
using HouseHoldBudget.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Contracts
{
    public interface IHouseHold
    {
        Task Create(CreateViewModel model, string userId);

        Task AddHouseHoldToCollectionAsync(int houseHoldId, string userId);
        Task<IEnumerable<HouseHold>> GetHouseholdAsync();
    }
}
