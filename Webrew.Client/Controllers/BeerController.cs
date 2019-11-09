using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webrew.Managers.Interfaces;
using Webrew.Models.Beers;

namespace webrew_dotnet.Controllers
{
    public class BeerController : ApiControllerBase
    {
        private readonly ILogger<BeerController> _logger;
        private readonly IBeerManager Manager;
        public BeerController(ILogger<BeerController> logger, IBeerManager manager)
        {
			Manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetBeer(string id)
        {
			var beer = await Manager.GetBeer(id);
            return Ok(beer);
        }

        [HttpPost("update")]
		public async Task<IActionResult> UpdateBeer(string id, Beer beer)
		{
			var result = await Manager.UpdateBeer(id, beer);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
        
        [HttpPost("remove")]
		public async Task<IActionResult> RemoveBeer(string id)
		{
			var result = await Manager.RemoveBeer(id);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
	}
}
