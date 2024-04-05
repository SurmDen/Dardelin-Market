namespace DardelinMarket.Data
{
    public class OrderModel
    {
        public long Id { get; set; }

        public long ProdId { get; set; }

        public int Count { get; set; }

        public Order Order { get; set; }

        public long OrderId { get; set; }
    }
}
