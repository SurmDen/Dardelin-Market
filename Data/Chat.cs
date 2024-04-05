namespace DardelinMarket.Data
{
    public class Chat
    {
        public long Id { get; set; }

        public string ChatName { get; set; }

        public long AdminId { get; set; }

        public long UserId { get; set; }

        public List<Message> Messages { get; set; }
    }
}
