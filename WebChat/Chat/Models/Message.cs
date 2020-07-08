using System;
using WebChat.Chat.Models.Interfaces;
using WebChat.Utility;

namespace WebChat.Chat.Models
{
    [Serializable]
    public sealed class Message
    {
        private string _user;
        private string _text;
        private string _time;

        public int Id { get; set; }

        public string User
        {
            get => _user;
            set => _user = value.FillEmpty("Guest")
                .RemoveHtmlTags()
                .DeleteAdminName()
                .ReplaceName()
                .Trim()
                .RemoveSpaces()
                .TrimSize(40);
        }
        
        public string Text
        {
            get => _text;
            set => _text = value.RemoveHtmlTags()
                .TrimSize(400)
                .Trim();
        }
        
        public string Time
        {
            get => _time;
            set => _time = value.RemoveHtmlTags() ?? DateTime.Now.ToString("hh:mm:ss");
        }
    }
}