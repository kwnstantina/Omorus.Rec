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

        //[HttpGet("user/{userId:Guid}/simple")]
        //public async Task<IActionResult> CreateInterestWithSubInterest([FromRoute] InterestWithSubInterestForCreateDTO interestSubInterestDTO)
        //{
        //  public class RecommendationService
        //{
        //    private readonly IDriver _driver;

        //    public RecommendationService(IDriver driver)
        //    {
        //        _driver = driver;
        //    }

        //    public async Task<List<string>> GetRecommendationsAsync(string userId)
        //    {
        //        var session = _driver.AsyncSession();

        //        try
        //        {
        //            var result = await session.RunAsync(@"
        //        MATCH (u:User)-[:HAS_INTEREST]->(i:Interest)-[:HAS_SUBINTEREST]->(si:SubInterest)
        //        WHERE u.id = $userId
        //        RETURN si.name AS recommended_subinterests",
        //                new { userId });

        //            var recommendations = new List<string>();
        //            while (await result.FetchAsync())
        //            {
        //                recommendations.Add(result.Current["recommended_subinterests"].As<string>());
        //            }

        //            return recommendations;
        //        }
        //        finally
        //        {
        //            await session.CloseAsync();
        //        }
        //    }
        //}


        //[HttpGet("content-based/{userId}")]
        //public async Task<IActionResult> GetContentBasedRecommendations(string userId)
        //{
        //    var userSubInterests = await GetUserSubInterestsAsync(userId);
        //    var allSubInterests = GetAllSubInterests();

        //    var recommendations = RecommendSubInterests(userSubInterests, allSubInterests);
        //    return Ok(recommendations);

        //public List<SubInterest> RecommendSubInterests(List<SubInterest> userSubInterests, List<SubInterest> allSubInterests)
        //{
        //    var recommendations = new List<SubInterest>();

        //    foreach (var userSub in userSubInterests)
        //    {
        //        foreach (var candidate in allSubInterests)
        //        {
        //            if (!userSubInterests.Contains(candidate)) // Avoid recommending already known subinterests
        //            {
        //                double similarity = CalculateCosineSimilarity(userSub.Keywords, candidate.Keywords);
        //                if (similarity > threshold) // Define a threshold for similarity
        //                {
        //                    recommendations.Add(candidate);
        //                }
        //            }
        //        }
        //    }

        //    return recommendations.Distinct().ToList(); // Remove duplicates
        //}
        //}
    }
}