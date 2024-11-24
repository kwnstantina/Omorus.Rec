using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmurusRecommender.Commands.Tags;
using OmurusRecommender.Models.DTOs;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Controllers
{
    [ApiController]
    [Route("api/tag")]
    public class TagGenerationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagGenerationController(IMediator mediator) => _mediator = mediator;

        [HttpPost("")]
        public async Task<IActionResult> CreateUserNode([FromBody] CreateTagRecommendationDTO createTagRecommendationDTO)
        {
            var command = new GenerateInterestSubInterestTagsCommand { CreateTagRecommendation = createTagRecommendationDTO };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);

        }

    }
}
