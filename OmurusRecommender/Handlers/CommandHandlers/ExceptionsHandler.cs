namespace OmurusRecommender.Handlers.CommandHandlers
{
    // Command Result Base Class
    public abstract class CommandResult
    {

        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public object? Data { get; set; } = null;

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, string message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }

    // Command Success Result
    public class CommandSuccessResult : CommandResult
    {

        public CommandSuccessResult(string message = "Command executed successfully.", object data = default)
        : base(true, message, data)
        {

        }
    }

    // Command Failure Result
    public class CommandFailureResult : CommandResult
    {
        public CommandFailureResult(string message)
            : base(false, message)
        {
        }
    }
}

