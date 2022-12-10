using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public IActionResult GetCurrentTime()
        {
            return Ok(new { currentTime = DateTime.Now.ToLocalTime() });
        }
    }
}

