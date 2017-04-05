using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using Sticky_Backend.Models;

namespace Object
{
    class Group
    {
        public string name { get; set; }

        public string creator { get; set; }

        //Chat not yet added

        public Dictionary<string, Project> projects = new Dictionary<string, Project>();

        public Dictionary<string, User> onlineUsers = new Dictionary<string, User>();




        Group(string name)
        {
            //retrieve projects from database and construct them

        }

        public void AddOnlineUser(Sticky_Backend.Models.User user)
        {
            if (!onlineUsers.ContainsKey(user.username))
            {
                onlineUsers.Add(user.name, user);
            }
            
        }

        public void RemoveOnlineUser(string username)
        {
            if (onlineUsers.ContainsKey(username))
            {
                onlineUsers.Remove(name);
            }
        }

    }
}
