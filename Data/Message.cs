namespace DardelinMarket.Data
{
    public class Message
    {
        public long Id { get; set; }

        public string UserEmail{ get; set; }

        public string MessageContext { get; set; }

        public Chat Chat { get; set; }

        public long ChatId { get; set; }
    }
}
