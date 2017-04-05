using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using RequestResponse;

namespace Object
{
    //Caching system to keep track of the groups online
    class Groups
    {
        //Currently, only caches online groups, but could cache all groups
        Dictionary<string, Sticky_Backend.Models.Group> groups = new Dictionary<string, Sticky_Backend.Models.Group>();

        public void GroupMessage(string groupName, Response msg)
        {
            //send to All Users
            //store in Database
        }

        public void AddGroup(Sticky_Backend.Models.Group group)
        {
            if (group.name != null && !groups.ContainsKey(group.name))
            {
                groups.Add(group.name, group);
            }
        }

        public void RemoveGroup(Sticky_Backend.Models.Group group)
        {
            if (groups.ContainsKey(group.name))
            {
                groups.Remove(group.name);
            }
        }
    }
}
