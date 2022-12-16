using HouseHoldBudget.Core.Contracts;
using HouseHoldBudget.Core.Models.Budget;
using HouseHoldBudget.Core.Models.HouseHolds;
using HouseHoldBudget.Core.Services;
using HouseHoldBudget.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Humanizer.In;

namespace HouseHoldBudget.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private readonly IBudgetService budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> AddBudget()
        {
            var model = new AddBudgetViewModel()
            {
                TypeOfAccounts = await budgetService.GetTypeOfAccountAsync(),
                Categories = await budgetService.GetCategoryAsync(),
                Currencies = await budgetService.GetCurrencyAsync()
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AddBudget(AddBudgetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await budgetService.Create(model, userId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Wrong");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyBudget()
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await budgetService.GetMyBudget(userId);

            return View("MyBudget", model);
        }

        public async Task<IActionResult> Delete(int budgetInitialId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await budgetService.RemoveBudgetInitialFromCollectionAsync(budgetInitialId, userId);

            return RedirectToAction(nameof(MyBudget));
        }
    }
}
