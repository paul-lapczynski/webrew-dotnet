using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Webrew.Common.Models;
using Webrew.Managers.Interfaces;

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
        public async Task<IActionResult> GetBeer(ObjectId id)
        {
			var beer = await Manager.GetBeer(id);
            return Ok(beer);
        }

        [HttpPost("update/{id}")]
		public async Task<IActionResult> UpdateBeer([FromRoute] ObjectId id, Beer beer)
		{
			var result = await Manager.UpdateBeer(id, beer);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
        
        [HttpPost("remove")]
		public async Task<IActionResult> RemoveBeer(ObjectId id)
		{
			var result = await Manager.RemoveBeer(id);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
	}
}
