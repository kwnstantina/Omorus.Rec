using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.SubInterests;

namespace OmurusRecommender.Commands
{
    public class CreateSubInterestNodeCommand : IRequest<CommandResult>
    {
        public SubInterest? SubInterestNode { get; set; }

    }
}
