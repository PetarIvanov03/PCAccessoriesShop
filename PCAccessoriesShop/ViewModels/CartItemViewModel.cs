namespace PCAccessoriesShop.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
