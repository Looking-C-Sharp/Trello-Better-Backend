 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using Sticky_Backend.Models;

namespace Object
{
    class Users
    {

        Dictionary<string, string> usernameToId = new Dictionary<string, string>();

        Dictionary<string, User> users = new Dictionary<string, User>();

        //Dictionary<User, MessageQueue> userQueues = new Dictionary<User, MessageQueue>();

        public string GetId(string username)
        {
            string id;
            usernameToId.TryGetValue(username, out id);
            return id;
        }

        public void AddUser(User user, string id)
        {
            users.Add(user.username, user);
            usernameToId.Add(user.username, id);
        }
    }
}
