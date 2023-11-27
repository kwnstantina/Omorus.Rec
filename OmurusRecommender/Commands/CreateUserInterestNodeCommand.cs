using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.DTOs;
using OmurusRecommender.Models.Interests;
using OmurusRecommender.Models.SubInterests;

namespace OmurusRecommender.Commands
{
    public class CreateUserInterestNodeCommand : IRequest<CommandResult>
    {
        public UserInterestDTO? UserIntrestSubInterestNode{ get; set;}
       

    }
}
