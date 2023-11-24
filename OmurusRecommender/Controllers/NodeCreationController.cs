using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmurusRecommender.Models.Interest;
using OmurusRecommender.Models.SubInterest;
using OmurusRecommender.Models.User;
using OmurusRecommender.Services.Implementations.Neo4jProvider;
using OmurusRecommender.Services.Interfaces;

namespace OmurusRecommender.Controllers
{

    [ApiController]
    [Route("api/nodes")]
    public class NodeCreationController : ControllerBase
    {
        private readonly ICreateNode<User> _createUserNode;
        private readonly ICreateNode<Interest> _createInterestNode;
        private readonly ICreateNode<SubInterest> _createSubInterestNode;


        public NodeCreationController( ICreateNode<User> createUserNode, ICreateNode<Interest> createInterestNode, ICreateNode<SubInterest> createSubInterestNode)
        {

            _createUserNode = createUserNode;
            _createInterestNode = createInterestNode;
            _createSubInterestNode = createSubInterestNode;
        }

        [HttpPost("user")]
        public IActionResult CreateUserNode([FromBody] User userModel)
        {
            var createUser=_createUserNode.CreateNode(userModel);
            return Ok(createUser);
        }

        [HttpPost("interest")]
        public IActionResult CreateInterest([FromBody] Interest interestModel)
        {
            var createInterest= _createInterestNode.CreateNode(interestModel);
            return Ok(createInterest);
        }

        [HttpPost("subinterest")]
        public IActionResult CreateSubInterest([FromBody] SubInterest subInterestModel)
        {
            var createSubInterest=_createSubInterestNode.CreateNode(subInterestModel);
            return Ok(createSubInterest);
        }
    }
}
