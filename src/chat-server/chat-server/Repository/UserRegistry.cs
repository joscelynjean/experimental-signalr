using chat_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chat_server.Repository
{
    public class UserRegistry
    {
        private static UserRegistry instance;

        public Dictionary<String, UserInfo> userRegistry;

        private UserRegistry() {
            userRegistry = new Dictionary<String, UserInfo>();
        }

        public static UserRegistry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRegistry();
                }
                return instance;
            }
        }

        public UserInfo[] GetAllUserInfo()
        {
            return userRegistry.Values.ToArray<UserInfo>();
        }

        public UserInfo GetUserInfo(String connectionId)
        {
            UserInfo userInfo = null;
            bool available = userRegistry.TryGetValue(connectionId, out userInfo);

            return userInfo;
        }

        public void AddUserInfo(String connectionId, UserInfo userInfo)
        {
            userRegistry.Add(connectionId, userInfo);
        }

        public void UpdateUserInfo(String connectionId, UserInfo userInfo)
        {
            userRegistry[connectionId] = userInfo;
        }

        public void RemoveUserInfo(String connectionId)
        {
            userRegistry.Remove(connectionId);
        }

    }
}