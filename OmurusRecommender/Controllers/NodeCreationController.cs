using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmurusRecommender.Commands;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.Interest;
using OmurusRecommender.Models.SubInterest;
using OmurusRecommender.Models.User;
using OmurusRecommender.Services.Implementations.Neo4jProvider;
using OmurusRecommender.Services.Interfaces;
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


        //[HttpPost("interest")]
        //public IActionResult CreateInterest([FromBody] Interest interestModel)
        //{
        //    var createInterest = _createInterestNode.CreateNode(interestModel);
        //    return Ok(createInterest);
        //}

        //[HttpPost("subinterest")]
        //public IActionResult CreateSubInterest([FromBody] SubInterest subInterestModel)
        //{
        //    var createSubInterest = _createSubInterestNode.CreateNode(subInterestModel);
        //    return Ok(createSubInterest);
        //}
    }

}
