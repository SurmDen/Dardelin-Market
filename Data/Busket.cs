namespace DardelinMarket.Data
{
    public class Busket
    {
        public long Id { get; set; }

        public List<BusketModel> BusketModels { get; set; }

        public Customer Customer { get; set; }

        public long CustomerId { get; set; }
    }
}
