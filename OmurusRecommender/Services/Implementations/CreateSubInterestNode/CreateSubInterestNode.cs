using Neo4j.Driver;
using OmurusRecommender.Models.SubInterest;
using OmurusRecommender.Queries;
using OmurusRecommender.Services.Interfaces;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Services.Implementations.CreateSubInterestNode
{
    public class CreateSubInterestNode : ICreateNode<SubInterest>
    {
        private readonly INeo4jProvider _neo4jProvider;
        public CreateSubInterestNode(
         INeo4jProvider neo4jProvider
        )
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<string> CreateNode(SubInterest subInterest)
        {

            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                var query = CypherQueries.CreateSubInterest;
                var nodeParameters = new NodeParameters<SubInterest>(subInterest);
                var parameters = nodeParameters.GetParameters();
                var result = await session.ExecuteWriteAsync(
                    async transaction =>
                    {
                        var resultCursor = await transaction.RunAsync(query, parameters);
                        return await resultCursor.SingleAsync();
                    });

                var resultProperty = result.Values;

                return resultProperty != null
                       ? ResultMessages.SubInterestCreatedSuccessfully
                       : ResultMessages.QueryResultMissing;
            }
            catch (Exception ex)
            {
                return Utils.Utilities.FormatMessage(ResultMessages.FailedToCreateSubInterest, ex.Message);
            }
        }
    }
}
