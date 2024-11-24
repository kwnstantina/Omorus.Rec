using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.Interests;

namespace OmurusRecommender.Commands
{
    public class CreateInterestNodeCommand : IRequest<CommandResult>
    {
        public Interest? InterestNode { get; set; }

    }
}
