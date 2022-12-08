using HouseHoldBudget.Core.Contracts;
using HouseHoldBudget.Core.Models.HouseHold;
using HouseHoldBudget.Infrastructure.Data;
using HouseHoldBudget.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Services
{
    public class HouseHoldService : IHouseHold
    {
        private readonly IRepository repo;

        public HouseHoldService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddHouseHoldToCollectionAsync(int houseHoldId, string userId)
        {
            var user = await repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserHouseHolds)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user");
            }

            var houseHold = await repo.All<HouseHold>().FirstOrDefaultAsync(m => m.Id == houseHoldId);

            if (houseHold == null)
            {
                throw new ArgumentException("Invalid household Id");
            }

            if (!user.UserHouseHolds.Any(m => m.HouseHoldId == houseHoldId))
            {
                user.UserHouseHolds.Add(new UserHouseHold()
                {
                    HouseHold = houseHold,
                    User = user,
                    HouseHoldId = houseHoldId,
                    UserId = userId
                });

                await repo.SaveChangesAsync();
            }
        }

            public async Task Create(CreateViewModel model)
            {
                var houseHold = new HouseHold()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address
                };

                await repo.AddAsync(houseHold);
                await repo.SaveChangesAsync();
            }
    }
        
}
