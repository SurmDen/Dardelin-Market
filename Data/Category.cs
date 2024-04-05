namespace DardelinMarket.Data
{
    public class Category
    {
        public long Id { get; set; }

        public string CategoryName { get; set; }

        public string ImagePath { get; set; }

        public List<Product> Products { get; set; }
    }
}
