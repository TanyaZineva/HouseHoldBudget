using HouseHoldBudget.Core.Contracts;
using HouseHoldBudget.Core.Models.Budget;
using HouseHoldBudget.Infrastructure.Data;
using HouseHoldBudget.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
                .Select(m=> new MyBudgetViewModel
                {
                    Id= m.BudgetInitial.Id,
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

        public async Task<List<List<MyHouseHoldBudgetViewModel>>> GetMyHouseHoldBudget(string userId)
        {
                
            var householdId = await repo.All<UserHouseHold>()
                .Where(u => u.UserId == userId)
                .Include(h=> h.HouseHold)
                .Select(m => m.HouseHoldId)
                .FirstOrDefaultAsync();

            var users = await repo.All<UserHouseHold>()  
                .Where(u => u.HouseHoldId == householdId)
                .ToListAsync();


            List<List<MyHouseHoldBudgetViewModel>> userBudgets = new List<List<MyHouseHoldBudgetViewModel>>();

            foreach (var user in users)
            {
                var userBudget = await repo.All<UserBudgetInitial>()
                .Where(u => u.UserId == user.UserId)
                .Include(ub => ub.BudgetInitial)
                .Select(m => new MyHouseHoldBudgetViewModel
                {
                    Id = m.BudgetInitial.Id,
                    Name = m.User.UserName,
                    TypeOfAccount = m.BudgetInitial.TypeOfAccount.Type,
                    Category = m.BudgetInitial.Category.Name,
                    Currency = m.BudgetInitial.Currency.CurrencyName,
                    Amount = m.BudgetInitial.Amount,
                    AmountInBgn = (m.BudgetInitial.Amount) * (decimal)(m.BudgetInitial.Currency.ExchangeRate),
                    Date = m.BudgetInitial.Date,
                    AdditionalInformation = m.BudgetInitial.AdditionalInformation
                })
                .ToListAsync();
                

                userBudgets.Add(userBudget);
            }

            return userBudgets;  
           
        }

        public async Task<EditBudgetViewModel> GetMyInitialBudget(int id)
        {
            var initial =await repo.All<UserBudgetInitial>()
                .Where(ib => ib.BudgetInitialId == id)
                .Include(b => b.BudgetInitial)
                .Select(b => new EditBudgetViewModel
                {
                    Id = b.BudgetInitial.Id,
                    CategoryId = b.BudgetInitial.Category.Id,
                    CurrencyId = b.BudgetInitial.Currency.Id,
                    TypeOfAccountId = b.BudgetInitial.TypeOfAccount.Id,
                    Amount = b.BudgetInitial.Amount,
                    AdditionalInformation = b.BudgetInitial.AdditionalInformation,
                    Date = b.BudgetInitial.Date
                })
                .FirstOrDefaultAsync();
                
           
            if (initial == null)
            {
                throw new ArgumentException("Invalid budget value");
            };

            return initial;

        }

        public async Task<IEnumerable<TypeOfAccount>> GetTypeOfAccountAsync()
        {
            return await repo.All<TypeOfAccount>()
                .ToListAsync();
        }

        public async Task RemoveBudgetInitialFromCollectionAsync(MyBudgetViewModel model, string userId)
        {

            var uInitial = await repo.All<UserBudgetInitial>()
                .Where(u => u.UserId == userId)
                .Where(b => b.BudgetInitialId == model.Id)
                .FirstOrDefaultAsync();
                

            if (uInitial==null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            
            repo.Delete<UserBudgetInitial>(uInitial);

            var bInitial = await repo.All<BudgetInitial>()
                .Where(b => b.Id == model.Id)
                .FirstOrDefaultAsync();

           repo.Delete<BudgetInitial>(bInitial);
           await repo.SaveChangesAsync();
        }

    }
}
