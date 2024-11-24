using Microsoft.AspNetCore.Mvc;
using OmurusRecommender.Handlers.CommandHandlers;

namespace OmurusRecommender.Utils
{
    public class Utilities
    {
        public static string FormatMessage(string message, string metaMessage)
        {
            return string.Format(message, metaMessage);
        }
   


        public static IActionResult CreateActionResult(CommandResult result)
        {
            if (result.Success)
            {
                return new OkObjectResult(new { Message = result.Message, Data = result.Data });
            }
            else
            {
                return new BadRequestObjectResult(new { Message = result.Message });
            }
        }
    }
}
