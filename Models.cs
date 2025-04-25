using System;
using System.Collections.Generic;
using System.Text;

namespace MealRecipeDataModel
{
    public class MealRecipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Drink { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string Instructions { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string Tags { get; set; }
        public string YoutubeUrl { get; set; }
        public string FontUrl { get; set; }
        public string ViewCountry { get; set; }
        public string ViewCity { get; set; }
        public DateTime ViewTime { get; set; }



        public ICollection<MealRecipeIngredient> Ingredients { get; set; }

        public MealRecipe()
        {
            Ingredients = new List<MealRecipeIngredient>();
        }

        public string ToStringFormat(string country, string city)
        {
            return $"{Id};{Name};{Category};{Country};{country};{city}";
        }
    }


    public class MealRecipeIngredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
