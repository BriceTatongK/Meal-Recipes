using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MealRecipeLogger
{
    public class WriteFunction(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<WriteFunction>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        [Function(nameof(WriteFunction))]
        public async Task Run([QueueTrigger("mealrecipe-write-queue", Connection = "AzureWebJobsStorage")] string message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message}");

            using StreamWriter sWriter = new("./Data/mealRecipeLog.json", true);

            await sWriter.WriteLineAsync(message);
        }
    }
}
