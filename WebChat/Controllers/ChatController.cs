using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using WebChat.Chat.Models;

namespace WebChat.Controllers
{
    public sealed class ChatController : ApiController
    {
        [EnableCors("AnotherPolicy")]
        public MessagesContainer ReadAll()
        {
            return Chat.Chat.ReadAll();
        }
        
        [EnableCors("AnotherPolicy")]
        public MessagesContainer ReadFrom(int id)
        {
            return Chat.Chat.ReadFrom(id);
        }

        [EnableCors("AnotherPolicy")]
        public bool Send(string user, string text)
        {
            if (user is null || text is null || text.Length < 1) return false;
            
            var message = new Message
            {
                Text = text,
                User = user
            };
            Chat.Chat.Send(message);

            return true;
        }
    }
}