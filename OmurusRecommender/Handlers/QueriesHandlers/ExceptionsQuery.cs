namespace OmurusRecommender.Handlers.QueriesHandlers
{

    // Query Result Base Class
    public abstract class QueryResult<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Data { get; protected set; }

        protected QueryResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }

    // Query Success Result
    public class QuerySuccessResult<T> : QueryResult<T>
    {
        public QuerySuccessResult(T data, string message = "Query executed successfully.")
            : base(true, message, data)
        {
        }
    }

    // Query Failure Result
    public class QueryFailureResult<T> : QueryResult<T>
    {
        public QueryFailureResult(string message)
            : base(false, message, default)
        {
        }
    }
}
