using System.Net.Http.Headers;

namespace WebRestoran.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }

        //public bool IsPreferredFood { get; set; } //dodati kasnije
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public Category? Category { get; set; } //? = nullable, proizvod pripada kategoriji
        public ICollection<OrderItem> OrderItems { get; set; } //proizvod moze biti u vise ordera
        public ICollection<FoodIngredient>? FoodIngredients { get; set; } //proizvod moze imati vise sastojaka


    }
}