using WebChat.Chat.Models;
using WebChat.Chat.Models.Interfaces;

namespace WebChat.Chat
{
    public static class Chat
    {
        private static readonly IContainer<Message> _container = new MessagesContainer(15);

        public static MessagesContainer ReadAll()
        {
            return (MessagesContainer)_container.Clone();
        }

        public static MessagesContainer ReadFrom(int id)
        {
            return (MessagesContainer)_container.CloneFrom(id);
        }

        public static void Send(Message message)
        {
            _container.Add(message);
        }
    }
}