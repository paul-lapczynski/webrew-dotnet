using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webrew.Common.Models;
using Webrew.Managers.Interfaces;

namespace webrew_dotnet.Controllers
{
    public class ReviewController : ApiControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewManager Manager;
        public ReviewController(ILogger<ReviewController> logger, IReviewManager manager)
        {
			Manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews(string BeerId)
        {
			var reviews = await Manager.GetReviews(BeerId);
            return Ok(reviews);
        }

        [HttpPost("add")]
		public async Task<IActionResult> AddReview(Review review)
		{
			var result = await Manager.AddReview(review);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}

        [HttpPost("update")]
		public async Task<IActionResult> UpdateReview(string id, Review review)
		{
			var result = await Manager.UpdateReview(id, review);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
        
        [HttpPost("remove")]
		public async Task<IActionResult> RemoveReview(string id)
		{
			var result = await Manager.RemoveReview(id);

			return Created(ControllerContext.HttpContext.Request.Host.ToUriComponent(), result);
		}
	}
}
