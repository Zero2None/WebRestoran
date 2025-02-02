namespace WebRestoran.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public ICollection<FoodIngredient> FoodIngredients { get; set; }
    }
}