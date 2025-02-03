using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebRestoran.Models
{
    public class Food
    {
        
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; } = "https://www.placeholder.com/333";
        public string? ImageThumbnailUrl { get; set; }

        //public bool IsPreferredFood { get; set; } //dodati kasnije
       

        [ValidateNever]
        public Category? Category { get; set; } //? = nullable, proizvod pripada kategoriji

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; } //proizvod moze biti u vise ordera

        [ValidateNever]
        public ICollection<FoodIngredient>? FoodIngredients { get; set; } //proizvod moze imati vise sastojaka
        public Food()
        {
            FoodIngredients = new List<FoodIngredient>();   //inicijalizacija liste sastojaka 
        }
    }
}