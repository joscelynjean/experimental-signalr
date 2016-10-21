using chat_server.Models;
using chat_server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace chat_server.Controllers
{
    /*[EnableCors(origins: "*", headers: "*", methods: "*")]*/
    public class UsersController : ApiController
    {

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return UserRegistry.Instance.GetAllUserInfo();
        }
    }
}
