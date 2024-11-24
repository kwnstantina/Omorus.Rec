using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.DTOs;

namespace OmurusRecommender.Commands
{
    public class CreateInterestsSubInterestsNodeCommand :IRequest<CommandResult>
    {
       public  List<InterestSubInterestDTO> IntrestSubInterestNode { get; set; } 
    }
}
