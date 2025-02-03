using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebRestoran.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        [ValidateNever]
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
    }
}