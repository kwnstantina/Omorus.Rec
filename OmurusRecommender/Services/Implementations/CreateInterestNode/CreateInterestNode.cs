using Neo4j.Driver;
using Neo4jClient;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Models.Interest;
using OmurusRecommender.Services.Interfaces;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Services.Implementations.CreateInterestNode
{
    public class CreateInterestNode : ICreateNode<Interest>
    {

        private readonly INeo4jProvider _neo4jProvider;

        public CreateInterestNode(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }

        public async Task<string> CreateNode(Interest interest)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                var query = CypherQueries.CreateInterest;
                var nodeParameters = new NodeParameters<Interest>(interest);
                var parameters = nodeParameters.GetParameters();
                var result = await session.ExecuteWriteAsync(
                    async transaction =>
                    {
                        var resultCursor = await transaction.RunAsync(query, parameters);
                        return await resultCursor.SingleAsync();
                    });

                var resultProperty = result.Values;

                return resultProperty != null
                       ? ResultMessages.InterestCreatedSuccessfully
                       : ResultMessages.QueryResultMissing;
            }
            catch (Exception ex)
            {
                return Utils.Utilities.FormatMessage(ResultMessages.FailedToCreateInterest, ex.Message);
            }
        }
    }
}
