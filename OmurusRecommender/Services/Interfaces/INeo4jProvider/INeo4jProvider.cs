using Neo4j.Driver;

namespace OmurusRecommender.Services.Interfaces.INeo4jProvider

{ 
    public interface INeo4jProvider
    {
         IDriver GetDriver();
    }
}
