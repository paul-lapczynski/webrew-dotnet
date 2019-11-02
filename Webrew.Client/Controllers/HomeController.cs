﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webrew.Managers.Interfaces;
using Webrew.Models.Coffees;

namespace webrew_dotnet.Controllers
{
    public class HomeController : ApiControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeManager Manager;
        public HomeController(ILogger<HomeController> logger, IHomeManager manager)
        {
			Manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoffees()
        {
			return Ok(await Manager.GetCoffees());
        }

		[HttpPost]
		public async Task<IActionResult> AddCoffee(Coffee coffee)
		{
			var result = await Manager.AddCoffee(coffee);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), coffee);
		}
	}
}
