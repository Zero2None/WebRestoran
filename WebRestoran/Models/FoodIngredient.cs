namespace WebRestoran.Models
{
    public class FoodIngredient
    {
        public int FoodId { get; set; }
        public Food? Food { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredients { get; set; }
    }
}