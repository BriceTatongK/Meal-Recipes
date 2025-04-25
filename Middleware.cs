using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MealRecipeLogClient
{
    public static class Middleware
    {
        public static IServiceCollection AddMealRecipeLogClient(this IServiceCollection collectionService)
        {
            collectionService.AddHttpClient<IMealRecipeLog, MealRecipeLog>((serviceProvider, client) =>
            {
               var cs = Environment.GetEnvironmentVariable("mealRecipeLoggerHost") ?? serviceProvider.GetRequiredService<IConfiguration>()["mealRecipeLoggerHost"];
                client.BaseAddress = new Uri(cs);
            });

            return collectionService;
        }
    }
}
