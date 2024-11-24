using MediatR;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.DTOs;

namespace OmurusRecommender.Commands.Tags
{
    public class GenerateInterestSubInterestTagsCommand : IRequest<CommandResult>
    {
        public CreateTagRecommendationDTO CreateTagRecommendation { get; set; }

    }
}
