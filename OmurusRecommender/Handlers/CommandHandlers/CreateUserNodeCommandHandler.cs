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
    public class CreateUserNodeCommandHandler : IRequestHandler<CreateUserNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateUserNodeCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<CommandResult> Handle(CreateUserNodeCommand request, CancellationToken cancellationToken)
        {

            
            try
            {
                var user = request.UserNode;
                // await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                // Create a Session for the `people` database

                await using var session =  _neo4jProvider.GetDriver().AsyncSession();

                var verify = _neo4jProvider.VerifyConnection();

                var query = CypherQueries.CreateUser;
                var parameters = new
                {
                    id = user?.Id.ToString(),
                    firstName = user?.FirstName,
                    email = user?.Email,
                    lastName = user?.LastName,
                    city = user?.City
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

