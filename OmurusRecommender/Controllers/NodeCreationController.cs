using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmurusRecommender.Commands;
using OmurusRecommender.Models.DTOs;
using OmurusRecommender.Models.Interests;
using OmurusRecommender.Models.SubInterests;
using OmurusRecommender.Models.User;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Controllers
{

    [ApiController]
    [Route("api/nodes")]
    public class NodeCreationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NodeCreationController(IMediator mediator) => _mediator = mediator;

        [HttpPost("user")]
        public async Task<IActionResult> CreateUserNode([FromBody] User userModel)
        {
            var command = new CreateUserNodeCommand { UserNode = userModel };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);

        }


        [HttpPost("interest")]
        public async Task<IActionResult> CreateInterest([FromBody] Interest interestModel)
        {
            var command = new CreateInterestNodeCommand { InterestNode = interestModel };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }

        [HttpPost("subinterest")]
        public async Task<IActionResult> CreateSubInterest([FromBody] SubInterest subInterestModel)
        {
             var command = new CreateSubInterestNodeCommand { SubInterestNode = subInterestModel };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }


        [HttpPost("user/interest")]
        public async Task<IActionResult> CreateUsertWithInterest([FromBody] UserInterestDTO userInterestSubInterestDTO)
        {
            var command = new CreateUserInterestNodeCommand { UserIntrestSubInterestNode = userInterestSubInterestDTO };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }

        [HttpPost("interests/subInterests")]
        public async Task<IActionResult> CreateInterestsWithSubInterests([FromBody] List<InterestSubInterestDTO> interestSubInterestDTO)
        {
            var command = new CreateInterestsSubInterestsNodeCommand { IntrestSubInterestNode = interestSubInterestDTO };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }

        [HttpPost("interest/subInterest")]
        public async Task<IActionResult> CreateInterestWithSubInterest([FromBody] InterestWithSubInterestForCreateDTO interestSubInterestDTO)
        {
            var command = new CreateInterestSubInterestNodeCommand { InterestSubInterestNode = interestSubInterestDTO };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }    
        
        [HttpPost("subInterests/relashionships")]
        public async Task<IActionResult> CreateSubInterestsRelationships()
        {
            var command = new CreateSubInterestsRelationshipsNodeCommand { };
            var result = await _mediator.Send(command);
            return Utilities.CreateActionResult(result);
        }
    }

}
