using System;

namespace ChatApp.MVVM.Model
{
    class MessageModel
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public string ImageSource { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsNativeOrigin { get; set; }
        public bool FirstMessage { get; set; }

        public MessageModel()
        {
            Username = null;
            UsernameColor = "#409aff";
            ImageSource = "./Icons/Contact.png";
            Message = "";
            Time = DateTime.Now;
            IsNativeOrigin = true;
            FirstMessage = false;
        }
    }
}
