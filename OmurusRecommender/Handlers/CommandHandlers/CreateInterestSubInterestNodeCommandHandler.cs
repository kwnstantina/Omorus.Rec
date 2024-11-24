using MediatR;
using OmurusRecommender.Commands;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Handlers.CommandHandlers
{
    public class CreateInterestSubInterestNodeCommandHandler : IRequestHandler<CreateInterestSubInterestNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateInterestSubInterestNodeCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<CommandResult> Handle(CreateInterestSubInterestNodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession();
                var query = CypherQueries.CreateInterestSubInterest;
                var interest = request?.InterestSubInterestNode.Interest;
                var subInterest = request?.InterestSubInterestNode.SubInterest;
                var parameters = new
                {
                    interestId = interest?.Id.ToString(),
                    subinterestId = subInterest?.Id.ToString()

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
