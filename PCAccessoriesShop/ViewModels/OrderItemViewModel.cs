namespace PCAccessoriesShop.ViewModels
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string? ImageUrl { get; set; }
    }
}
