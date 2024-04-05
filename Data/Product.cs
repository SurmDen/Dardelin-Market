namespace DardelinMarket.Data
{
    public class Product
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public string ImagePath { get; set; }

        public Category Category { get; set; }

        public long CategoryId { get; set; }

        public int Sales { get; set; }

    }
}
