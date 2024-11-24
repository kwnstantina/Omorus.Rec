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
                await using var session = _neo4jProvider.GetDriver().AsyncSession();
                var query = CypherQueries.CreateUserInterests;
                var parameters = new
                {
                    userId = request?.UserIntrestSubInterestNode?.UserId.ToString(),
                    interests = request?.UserIntrestSubInterestNode?.Interests?.Select(i => new { id = i.Id.ToString()}).ToList(),
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

