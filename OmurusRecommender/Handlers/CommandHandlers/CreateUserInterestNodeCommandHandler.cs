using MediatR;
using Neo4j.Driver;
using OmurusRecommender.Commands;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Handlers.CommandHandlers;
using OmurusRecommender.Models.User;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.CommandHandlers
{
    public class CreateUserInterestNodeCommandHandler : IRequestHandler<CreateUserInterestNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateUserInterestNodeCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<CommandResult> Handle(CreateUserInterestNodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                var query = CypherQueries.CreateUserInterest;
                var parameters = new
                {
                    userId = request?.UserIntrestSubInterestNode?.UserId,
                    interests = request?.UserIntrestSubInterestNode?.Interests?.Select(i => new { id = i.Id, title = i.Title }).ToList(),
                    subinterests = request?.UserIntrestSubInterestNode?.Subinterests?.Select(si => new { id = si.Id, title = si.Title }).ToList()
                };
                var result = await session.ExecuteWriteAsync(
                    async transaction =>
                    {
                        var resultCursor = await transaction.RunAsync(query, parameters);
                        return await resultCursor.SingleAsync();
                    });

                var resultProperty = result.Values;

                return resultProperty != null
                    ? new CommandSuccessResult(ResultMessages.UserCreatedSuccessfully)
                    : new CommandFailureResult(ResultMessages.QueryResultMissing);
            }
            catch (Exception ex)
            {
                return new CommandFailureResult(Utilities.FormatMessage(ResultMessages.FailedToCreateUser, ex.Message));

            }

        }
    }
}

