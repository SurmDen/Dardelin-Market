using DardelinMarket.Data;
using DardelinMarket.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;

namespace DardelinMarket.Hubs
{
    public class ChatHub : Hub
    {
        private IChatRepository chatRepository;

        private ICustomerRepository customerRepository;

        public ChatHub(IChatRepository chatRepository, ICustomerRepository customerRepository)
        {
            this.chatRepository = chatRepository;

            this.customerRepository = customerRepository;
        }

        public async Task Send(string message)
        {
            string name = Context.User.Identity.Name;

            string email = Context.User.FindFirst(ClaimTypes.Email)?.Value;

            Customer customer = customerRepository.GetCustomerByNameAndEmail(name, email);

            Chat chat;

            if (customer.Role == "User")
            {
                chat = chatRepository.GetChatByName(email);

                Message mess = new Message()
                {
                    MessageContext = message,

                    UserEmail = email,

                    Chat = chat
                };

                chatRepository.AddMessage(mess);

                await Clients.Group(chat.ChatName).SendAsync("Receive", message, email);
            }
            else
            {
                string userEmail = Context.GetHttpContext().Session.GetString("selectedemail");

                chat = chatRepository.GetChatByName(userEmail);

                Message mess = new Message()
                {
                    MessageContext = message,

                    UserEmail = email,

                    Chat = chat
                };

                chatRepository.AddMessage(mess);

                await Clients.Group(chat.ChatName).SendAsync("Receive", message, email);
            }
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string name = Context.User.Identity.Name;

                string email = Context.User.FindFirst(ClaimTypes.Email)?.Value;

                Customer customer  = customerRepository.GetCustomerByNameAndEmail(name, email);

                if (customer.Role == "User")
                {
                    Chat? chat = chatRepository.GetChatByName(customer.Email);

                    if (chat == null)
                    {
                        chat = new Chat()
                        {
                            ChatName = email,

                            AdminId = 1,

                            UserId = customer.Id
                        };

                        chatRepository.CreateChat(chat);
                    }

                    await Groups.AddToGroupAsync(Context.ConnectionId, chat.ChatName);
                }
                else
                {
                    string userEmail = Context.GetHttpContext().Session.GetString("selectedemail");

                    await Groups.AddToGroupAsync(Context.ConnectionId, userEmail);
                }
            }


            await base.OnConnectedAsync();
        }
    }
}
