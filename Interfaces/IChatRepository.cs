using DardelinMarket.Data;

namespace DardelinMarket.Interfaces
{
    public interface IChatRepository
    {
        public IEnumerable<Chat> GetChats();

        public Chat GetChatByName(string Name);

        public void CreateChat(Chat chat);

        public void AddMessage(Message message);

        public IEnumerable<Message> GetMessages(string chatName);
    }
}
