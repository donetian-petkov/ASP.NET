using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

[Authorize]
public class AgentController : Controller
{
    private readonly IAgentService agentService;

    public AgentController(IAgentService _agentService)
    {
        agentService = _agentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Become()
    {
        
        Console.WriteLine("This is the user id " + User.Id());

        if (await agentService.ExistsByIdAsync(User.Id()))
        {
            TempData[MessageConstant.ErrorMessage] = "You are already an agent!";

            return RedirectToAction("Index", "Home");
        }

        var model = new BecomeAgentModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentModel model)
    {
        var userId = User.Id();

        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        if (await agentService.ExistsByIdAsync(User.Id()))
        {
            TempData[MessageConstant.ErrorMessage] = "You are already an agent!";

            return RedirectToAction("Index", "Home");
        }

        if (await agentService.UserWithPhoneNumberExists(model.PhoneNumber))
        {
            TempData[MessageConstant.ErrorMessage] = "Phone Number Already Exists!";
            
            return RedirectToAction("Index", "Home");
        }

        if (await agentService.UserHasRents(userId))
        {
            TempData[MessageConstant.ErrorMessage] = "User Has Rents!";
            
            return RedirectToAction("Index", "Home");
        }

        await agentService.Create(userId, model.PhoneNumber);
        
        TempData[MessageConstant.SuccessMessage] = "You are now an agent!";

        return RedirectToAction("Index", "Home");
    }
    
    
}