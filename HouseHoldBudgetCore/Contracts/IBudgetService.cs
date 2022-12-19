using HouseHoldBudget.Core.Models.Budget;
using HouseHoldBudget.Core.Models.HouseHolds;
using HouseHoldBudget.Infrastructure.Data;

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
        Task <IEnumerable<MyBudgetViewModel>>GetMyBudget(string userId);
        Task RemoveBudgetInitialFromCollectionAsync(MyBudgetViewModel model, string userId);
        Task<EditBudgetViewModel> GetMyInitialBudget(int id);
        Task<List<List<MyHouseHoldBudgetViewModel>>> GetMyHouseHoldBudget(string userId);

    }
}
