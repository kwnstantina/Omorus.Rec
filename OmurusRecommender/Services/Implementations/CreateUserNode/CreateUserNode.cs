using Neo4j.Driver;
using OmurusRecommender.Cyphers;
using OmurusRecommender.Models.User;
using OmurusRecommender.Services.Interfaces;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;
using OmurusRecommender.Utils;

namespace OmurusRecommender.Services.Implementations.CreateUserNode
{
    public class CreateUserNode : ICreateNode<User>
    {
        private readonly INeo4jProvider _neo4jProvider;

        public CreateUserNode(INeo4jProvider neo4jProvider)
        {
            _neo4jProvider = neo4jProvider;
        }


        public async Task<string> CreateNode(User user)
        {
            try
            {
                await using var session = _neo4jProvider.GetDriver().AsyncSession(action => action.WithDatabase("OmorusRec"));
                var query = CypherQueries.CreateUser;
                var nodeParameters = new NodeParameters<User>(user);
                var parameters = nodeParameters.GetParameters();
                var result = await session.ExecuteWriteAsync(
                    async transaction =>
                    {
                        var resultCursor = await transaction.RunAsync(query, parameters);
                        return await resultCursor.SingleAsync();
                    });

                var resultProperty = result.Values;

                return resultProperty != null
                       ? ResultMessages.UserCreatedSuccessfully
                       : ResultMessages.QueryResultMissing;
            }
            catch (Exception ex)
            {
                return Utilities.FormatMessage(ResultMessages.FailedToCreateUser, ex.Message);
            }
        }

    }
}
