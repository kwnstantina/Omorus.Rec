using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.User;

namespace OmurusRecommender.Commands
{
    public class CreateUserNodeCommand : IRequest<CommandResult>
    {
        public User? UserNode { get; set; }

    }
}
