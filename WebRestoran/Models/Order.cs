namespace WebRestoran.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //public string Address { get; set; }
        //public string Phone { get; set; }
        public string? Comment { get; set; }
        public decimal TotalAmmount { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
