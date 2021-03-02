using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.CommonUtility.Interface
{
    public class Messenger
    {
        private string _messageType = "";
        public Messenger(string messageType)
        {
            _messageType = messageType;
        }
        public Task<bool> SendMessage()
        {
            switch (_messageType)
            {
                case "Email":
                   return new Email().SendMessage();
                    
                case "Slack":
                    return new SlackClient().SendMessage();               
            }
        }
    }
}
