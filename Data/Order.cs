namespace DardelinMarket.Data
{
    public class Order
    {
        public long Id { get; set; }

        public List<OrderModel> OrderModels { get; set; }

        public Customer Customer { get; set; }

        public long CustomerId { get; set; }

        public bool IsShipped { get; set; }

    }
}
