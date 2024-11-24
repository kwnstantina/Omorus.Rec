using Neo4j.Driver;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;

namespace OmurusRecommender.Services.Implementations.Neo4jProvider
{
    public class Neo4jProvider : INeo4jProvider, IDisposable
    {

        private IDriver _driver;
        private readonly string _uri;
        private readonly string _username;
        private readonly string _password;
        private bool _disposed;
        public Neo4jProvider(string uri, string username, string password)
        {
            _uri = uri;
            _username = username;
            _password = password;
            _driver = GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(username, password));
        }

        public IDriver GetDriver()
        {
            // Check if the driver has been disposed, and create a new one if necessary
            if (_driver == null || _disposed)
            {
                _driver = GraphDatabase.Driver(new Uri(_uri), AuthTokens.Basic(_username, _password));

            }

            return _driver;
        }
        public async Task VerifyConnection()
        {
            await _driver.VerifyConnectivityAsync();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _driver?.Dispose();
                _disposed = true;
            }

        }

    }
}
