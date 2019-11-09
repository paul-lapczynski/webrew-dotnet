using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webrew.Common.Models;
using Webrew.Managers.Interfaces;

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
        public async Task<IActionResult> GetBeers()
        {
			var beers = await Manager.GetBeers();
            return Ok(beers);
        }

		[HttpPost]
		public async Task<IActionResult> AddBeer(Beer beer)
		{
			var result = await Manager.AddBeer(beer);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
	}
}
