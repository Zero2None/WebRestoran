namespace WebRestoran.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }  
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}