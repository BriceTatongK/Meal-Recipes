using Azure.Storage.Queues;
using MealRecipeDataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MealRecipeLogClient
{
    public class MealRecipeLog : IMealRecipeLog
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public MealRecipeLog(ILoggerFactory loggerFactory, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<MealRecipeLog>();
            _configuration = configuration;
            _httpClient = httpClient;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public async Task<List<MealRecipe>> ReadAsync()
        {
            List<MealRecipe> mealRecipes = null;

            try
            {
                mealRecipes = await _httpClient.GetFromJsonAsync<List<MealRecipe>>("api/List");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return mealRecipes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<bool> WriteAsync(string msg)
        {
            bool ret = false;

            try
            {
                // enqueue msg
                var cs = _configuration["AzureWebJobsStorage"];
                var qName = _configuration["mealRecipeQueuename"];
                QueueClient queueClient = new QueueClient(cs, qName, new QueueClientOptions
                {
                    MessageEncoding = QueueMessageEncoding.Base64
                });
                await queueClient.CreateIfNotExistsAsync();

                var r = await queueClient.SendMessageAsync(msg);

                if (!r.GetRawResponse().IsError)
                {
                    ret = true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                ret = false;
            }

            return ret;
        }
    }
}