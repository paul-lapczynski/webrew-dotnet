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
        public async Task<IActionResult> GetBeer(string Id)
        {
			var beer = await Manager.GetBeer(Id);
            return Ok(beer);
        }

        [HttpPost("update")]
		public async Task<IActionResult> UpdateBeer(string Id, Beer beer)
		{
			var result = await Manager.UpdateBeer(Id, beer);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
        
        [HttpPost("remove")]
		public async Task<IActionResult> RemoveBeer(string Id)
		{
			var result = await Manager.RemoveBeer(Id);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
	}
}
