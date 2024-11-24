using MediatR;
using OmurusRecommender.Commands;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Handlers.CommandHandlers
{
    public class CreateSubInterestsRelationshipsNodeCommandHandler : IRequestHandler<CreateSubInterestsRelationshipsNodeCommand, CommandResult>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateSubInterestsRelationshipsNodeCommandHandler(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<CommandResult> Handle(CreateSubInterestsRelationshipsNodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession();
                var query = CypherQueries.CreateSubInterestRelationships;

                await session.ExecuteWriteAsync(
                   async transaction =>
                   {
                       var resultCursor = await transaction.RunAsync(query);

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
