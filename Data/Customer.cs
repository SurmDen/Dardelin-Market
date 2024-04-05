namespace DardelinMarket.Data
{
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string PostAddress { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public Busket Busket { get; set; }

        public List<Order> Orders { get; set; }

    }
}
