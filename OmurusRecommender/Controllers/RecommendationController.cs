using Microsoft.AspNetCore.Mvc;

namespace OmurusRecommender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendationController : ControllerBase
    {
       
        private readonly ILogger<RecommendationController> _logger;

        public RecommendationController(ILogger<RecommendationController> logger)
        {
            _logger = logger;
        }

      
    }
}