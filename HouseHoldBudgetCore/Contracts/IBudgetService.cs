using HouseHoldBudget.Core.Models.Budget;
using HouseHoldBudget.Core.Models.HouseHolds;
using HouseHoldBudget.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseHoldBudget.Core.Contracts
{
    public interface IBudgetService
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task<IEnumerable<Currency>> GetCurrencyAsync();
        Task<IEnumerable<TypeOfAccount>> GetTypeOfAccountAsync();
        Task Create(AddBudgetViewModel model, string userId);
        Task AddBudgetInitialToCollectionAsync(int budgetInitialId, string userId);
        public Task<bool> ExistsUserById(string userId);
    }
}
