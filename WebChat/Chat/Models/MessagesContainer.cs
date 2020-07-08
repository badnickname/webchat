using System;
using System.Collections.Generic;
using System.Linq;
using WebChat.Chat.Models.Interfaces;

namespace WebChat.Chat.Models
{
    [Serializable]
    public sealed class MessagesContainer : IContainer<Message>
    {
        private readonly int _max;
        private const int MinMessages = 1;
        private List<Message> _messages = new List<Message>();
        private int _idEnumerator = 1;
        
        // Container's content field
        public IList<Message> Messages
        {
            get => _messages;
            private set => _messages = (List<Message>) value;
        }

        public MessagesContainer(int maxCount)
        {
            _max = maxCount >= MinMessages ? maxCount : MinMessages;
        }

        public void Add(Message message)
        {
            if (_messages.Count >= _max)
            {
                _messages.RemoveAt(0);
            }
            message.Id = message.Id == default ? _idEnumerator++ : message.Id;
            message.Text ??= "";
            message.User ??= "";
            message.Time ??= DateTime.Now.ToString("hh:mm:ss");
            _messages.Add(message);
        }

        public object Clone()
        {
            return new MessagesContainer(_max)
            {
                Messages = Messages
            };
        }

        public object CloneFrom(int id)
        {
            var container = new MessagesContainer(_max);
            foreach (var message in Messages.Where(i=>i.Id > id))
            {
                container.Add(message);
            }

            return container;
        }
    }
}