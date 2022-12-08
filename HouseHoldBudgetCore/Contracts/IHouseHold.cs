using HouseHoldBudget.Core.Models.HouseHold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Contracts
{
    public interface IHouseHold
    {
        Task Create(CreateViewModel model);

        Task AddHouseHoldToCollectionAsync(int houseHoldId, string userId);
    }
}
