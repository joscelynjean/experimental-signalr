using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using chat_server.Repository;
using chat_server.Models;
using System.Threading.Tasks;

namespace chat_server.Hubs
{
    [HubName("user")]
    public class UserHub : Hub
    {

        public void RegisterUser(string username)
        {
            UserInfo userInfo = new UserInfo {
                Username = username,
                Status = 1
            };

            UserRegistry.Instance.AddUserInfo(Context.ConnectionId, userInfo);
            Clients.All.refreshUserList();
        }

        public void UpdateStatus(int status)
        {
            UserInfo userInfo = UserRegistry.Instance.GetUserInfo(Context.ConnectionId);
            userInfo.Status = status;

            UserRegistry.Instance.UpdateUserInfo(Context.ConnectionId, userInfo);
            Clients.All.refreshUserList();
        }

        public void UnregisterUser()
        {
            UserRegistry.Instance.RemoveUserInfo(Context.ConnectionId);
            Clients.All.refreshUserList();
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserRegistry.Instance.RemoveUserInfo(Context.ConnectionId);
            Clients.All.refreshUserList();
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}