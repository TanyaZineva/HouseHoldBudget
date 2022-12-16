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
              CurrencyId= model.CurrencyId,
              TypeOfAccountId= model.TypeOfAccountId,
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

        public async Task<IEnumerable<MyBudgetViewModel>> GetMyBudget(string userId)
        {
            var user = await repo.All<UserBudgetInitial>()
                .Where(u => u.UserId == userId)
                .Include(ub => ub.BudgetInitial)
                //.ThenInclude(c=> new{ c.Category, c.Currency, c.TypeOfAccount})
                .Select(m=> new MyBudgetViewModel
                {
                    TypeOfAccount = m.BudgetInitial.TypeOfAccount.Type,
                    Category = m.BudgetInitial.Category.Name,
                    Currency = m.BudgetInitial.Currency.CurrencyName,
                    Amount = m.BudgetInitial.Amount,
                    AmountInBgn = (m.BudgetInitial.Amount) * (decimal)(m.BudgetInitial.Currency.ExchangeRate),
                    Date = m.BudgetInitial.Date,
                    AdditionalInformation = m.BudgetInitial.AdditionalInformation
                })
                .ToListAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user;
        }

        public async Task<IEnumerable<TypeOfAccount>> GetTypeOfAccountAsync()
        {
            return await repo.All<TypeOfAccount>()
                .ToListAsync();
        }

        public async Task RemoveBudgetInitialFromCollectionAsync(int budgetInitialId, string userId)
        {

            var budgetInitial = await repo.All<UserBudgetInitial>()
                .Where(u => u.UserId == userId)
                .Where(b=> b.BudgetInitialId==budgetInitialId)
                .FirstOrDefaultAsync();

            if (budgetInitial==null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            repo.Delete<UserBudgetInitial>(budgetInitial);
        }
    }
}
