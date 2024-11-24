using MediatR;
using Neo4j.Driver;
using OmurusRecommender.Commands;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.CommandHandlers
{
    public class CreateSubInterestNodeCommandHandler : IRequestHandler<CreateSubInterestNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateSubInterestNodeCommandHandler(INeo4jProvider neo4jProvider) => _neo4jProvider = neo4jProvider;

        public async Task<CommandResult> Handle(CreateSubInterestNodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subInterest = request.SubInterestNode;
               // await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                await using var session = _neo4jProvider.GetDriver().AsyncSession();
                var query = CypherQueries.CreateSubInterest;
                var parameters = new
                {
                    id = subInterest?.Id.ToString(),
                    title = subInterest?.Title,
                    code = subInterest?.Code,
                    interestId = subInterest?.InterestId.ToString(),
                   
                };
                var result = await session.ExecuteWriteAsync(
                    async transaction =>
                    {
                        var resultCursor = await transaction.RunAsync(query, parameters);
                        return await resultCursor.SingleAsync();
                    });

                var resultProperty = result.Values;

                return resultProperty != null
                    ? new CommandSuccessResult(ResultMessages.SubInterestCreatedSuccessfully)
                    : new CommandFailureResult(ResultMessages.QueryResultMissing);
            }
            catch (Exception ex)
            {
                return new CommandFailureResult(Utilities.FormatMessage(ResultMessages.FailedToCreateSubInterest, ex.Message));

            }

        }
    }
}

