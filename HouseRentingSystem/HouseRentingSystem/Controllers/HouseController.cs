using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HouseController : Controller
{
    public async Task<IActionResult> All()
    {

        var model = new HousesQueryModel();
        
        return View(model);
    }

    public async Task<IActionResult> Mine()
    {
        var model = new HousesQueryModel();
        
        return View(model);
    }
}