using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using chat_server.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace chat_server.Hubs
{
    [HubName("conversation")]
    public class ConversationHub : Hub
    {
        public void ReceiveMessage(MessageInformation messageInformation)
        {
            // Send update of conversation to anyone
            Clients.All.updateConversation(messageInformation);
        }
    }
}