namespace WebRestoran.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Food> Products { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
