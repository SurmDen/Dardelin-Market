using DardelinMarket.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DardelinMarket.Data
{
    public class ChatRepository : IChatRepository
    {
        private DataContext context;

        public ChatRepository(DataContext context)
        {
            this.context = context;
        }

        public void AddMessage(Message message)
        {
            context.Messages.Add(message);

            context.SaveChanges();
        }

        public void CreateChat(Chat chat)
        {
            context.Chats.Add(chat);

            context.SaveChanges();
        }

        public Chat GetChatByName(string chatName)
        {
            Chat chat;

            try
            {
                chat = context.Chats.Include(c => c.Messages).First(c => c.ChatName == chatName);
            }
            catch (Exception)
            {
                chat = null;
            }

            return chat;
        }

        public IEnumerable<Chat> GetChats()
        {
            IEnumerable<Chat> chats =  context.Chats.Include(c => c.Messages);

            foreach (var c in chats)
            {
                foreach (var m in c.Messages)
                {
                    m.Chat = null;
                }
            }

            return chats;
        }

        public IEnumerable<Message> GetMessages(string chatName)
        {
            Chat chat = context.Chats.Include(c => c.Messages).First(c => c.ChatName == chatName);

            return chat.Messages;
        }
    }
}
