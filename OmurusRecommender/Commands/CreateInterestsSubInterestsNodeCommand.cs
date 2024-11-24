using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.DTOs;

namespace OmurusRecommender.Commands
{
    public class CreateInterestSubInterestNodeCommand :IRequest<CommandResult>
    {
       public InterestWithSubInterestForCreateDTO InterestSubInterestNode { get; set; } 
    }
}
