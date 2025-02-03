namespace WebRestoran.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Food> Products { get; set; }
    }
}