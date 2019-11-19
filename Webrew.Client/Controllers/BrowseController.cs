using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webrew.Common.Models;
using Webrew.Managers.Interfaces;

namespace webrew_dotnet.Controllers
{
    public class BrowseController : ApiControllerBase
    {
        private readonly ILogger<BrowseController> _logger;
        private readonly IBrowseManager Manager;
        public BrowseController(ILogger<BrowseController> logger, IBrowseManager manager)
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
	}
}
