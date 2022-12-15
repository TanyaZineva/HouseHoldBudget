using HouseHoldBudget.Core.Contracts;
using HouseHoldBudget.Core.Models.Budget;
using HouseHoldBudget.Infrastructure.Data;
using HouseHoldBudget.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IRepository repo;

        public BudgetService(IRepository _repo)
        {
            repo = _repo;
        }

        public Task AddBudgetInitialToCollectionAsync(int budgetInitialId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(AddBudgetViewModel model, string userId)
        {
            var budgetInitial = new BudgetInitial()
            {
              CategoryId= model.CategoryId,
              Category=model.Category,
              CurrencyId= model.CurrencyId,
              Currency= model.Currency,
              TypeOfAccountId= model.TypeOfAccountId,
              TypeOfAccount= model.TypeOfAccount,
              Amount= model.Amount,
              AdditionalInformation= model.AdditionalInformation,
              Date= model.Date
            };

            await repo.AddAsync(budgetInitial);
            await repo.SaveChangesAsync();

            var userBudgetInitial = new UserBudgetInitial()
            {
                UserId = userId,
                BudgetInitialId = budgetInitial.Id
            };
            await repo.AddAsync(userBudgetInitial);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsUserById(string userId)
        {
            return await repo.All<UserBudgetInitial>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await repo.All<Category>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Currency>> GetCurrencyAsync()
        {
            return await repo.All<Currency>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TypeOfAccount>> GetTypeOfAccountAsync()
        {
            return await repo.All<TypeOfAccount>()
                .ToListAsync();
        }
    }
}
