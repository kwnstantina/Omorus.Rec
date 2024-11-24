using MediatR;
using OmurusRecommender.Commands;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Handlers.CommandHandlers
{
    public class CreateInterestsSubInterestsNodeCommandHandler : IRequestHandler<CreateInterestsSubInterestsNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateInterestsSubInterestsNodeCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<CommandResult> Handle(CreateInterestsSubInterestsNodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession();
                var query = CypherQueries.CreateBulkInterestSubInterest;
                var parameters = new
                {
                    interests = request?.IntrestSubInterestNode.Select(i=>new {id = i.InterestIds.ToString()} ).ToList(),
                    subinterests = request?.IntrestSubInterestNode.Select(i=>new {id = i.SubInterestIds.ToString()} ).ToList(),

                };
                await session.ExecuteWriteAsync(
                   async transaction =>
                   {
                       var resultCursor = await transaction.RunAsync(query, parameters);

                   });


                return new CommandSuccessResult(ResultMessages.UserInterestCreatedSuccessfully);

            }
            catch (Exception ex)
            {
                return new CommandFailureResult(Utilities.FormatMessage(ResultMessages.FailedToCreateUser, ex.Message));

            }

        }
    }
}
