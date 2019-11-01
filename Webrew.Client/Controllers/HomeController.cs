﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Webrew.Data.Interfaces;
using Webrew.Interfaces;
using Webrew.Interfaces.Coffee;
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
        public async Task<List<ICoffee>> GetCoffees()
        {
			return await Manager.GetCoffees();
        }
    }
}
