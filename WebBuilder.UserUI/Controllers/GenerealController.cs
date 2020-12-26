using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBuilder.Business.Concrete;

namespace WebBuilder.UserUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerealController : ControllerBase
    {
       public GenerealController()
        {

        }
        [HttpPost]
        public IActionResult Create(string contact)
        {

            return Ok(new { Status = true, Data = "Message OK" });
        }
        [HttpGet]
        public IActionResult Index( )
        {

            return Ok("HASAN");
        }
    }
}