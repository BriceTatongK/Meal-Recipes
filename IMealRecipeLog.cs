using MealRecipeDataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealRecipeLogClient
{
    public interface IMealRecipeLog
    {
        Task<bool> WriteAsync(string data);
        Task<List<MealRecipe>> ReadAsync();
    }
}
