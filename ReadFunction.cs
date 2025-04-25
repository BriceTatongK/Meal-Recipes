using System.Net;
using System.Text.Json;
using MealRecipeDataModel;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MealRecipeLogger
{
    public class ReadFunction(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<ReadFunction>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Function("ReadFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "List")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                FileStreamOptions options = new()
                {
                    Mode = FileMode.OpenOrCreate,
                    Access = FileAccess.Read,
                    Share = FileShare.ReadWrite,
                    Options = FileOptions.Asynchronous
                };

                using StreamReader sReader = new("./Data/mealRecipeLog.json", options);

                var obj = new List<MealRecipe>();

                string? str;
                while ((str = await sReader.ReadLineAsync()) != null)
                {
                    var ret = JsonSerializer.Deserialize<MealRecipe>(str);

                    if (ret != null)
                    {
                        obj.Add(ret);
                    }
                }

                response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await response.WriteStringAsync(ex.Message);
            }

            return response;
        }
    }
}
