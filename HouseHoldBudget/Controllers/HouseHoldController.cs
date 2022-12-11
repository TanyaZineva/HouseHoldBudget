using HouseHoldBudget.Core.Contracts;
using HouseHoldBudget.Core.Models.HouseHolds;
using HouseHoldBudget.Core.Models.User;
using HouseHoldBudget.Core.Services;
using HouseHoldBudget.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Claims;

namespace HouseHoldBudget.Controllers
{
    public class HouseHoldController : Controller
    {
        private readonly IHouseHold houseHoldService;

        public HouseHoldController(IHouseHold houseHoldService)
        {
            this.houseHoldService = houseHoldService;    
        }
        public IActionResult OptionsAddOrCreate()
        {
            return View();
        }

        [HttpGet]
        public  IActionResult Create()
        {
            var model = new CreateViewModel();
            
            return View (model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await houseHoldService.Create(model, userId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Wrong");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddViewModel()
            {
             HouseHolds = await houseHoldService.GetHouseholdAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(int houseHoldId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await houseHoldService.AddHouseHoldToCollectionAsync(houseHoldId, userId);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
