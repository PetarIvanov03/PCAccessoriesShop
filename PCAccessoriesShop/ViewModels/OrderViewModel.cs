using System;
using System.Collections.Generic;

namespace PCAccessoriesShop.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(i => i.TotalPrice);
    }
}
