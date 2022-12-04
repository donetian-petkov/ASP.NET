using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebShopDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            return Ok();
        }
        
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            return Ok();
        }
    }
    
}