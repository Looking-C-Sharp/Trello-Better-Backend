using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sticky_Backend.Models;

namespace RequestResponse
{
    public class Request
    {
        public string id { get; set; }

        public bool login { get; set; }

        public bool logoff { get; set; } //This will kill all the threads

        public string type { get; set; } //GET,POST,UPDATE,DELETE

        public string target { get; set; } //group, user, project, item

        //public string targetID { get; set; }

        public User userData { get; set; }

        public List<Group> groupData { get; set; } = new List<Group>();

        public List<Project> projectData { get; set; } = new List<Project>();

        public string sentBy { get; set; } //id of the sender

        //public ItemData itemData { get; set; }

        //Static variables For convenience and consistency

        //For type
        public static string GET = "Get";

        public static string POST = "Post";

        public static string PUT = "Put";

        public static string DELETE = "Delete";

        //For target
        public static string GROUP = "Group";

        public static string USER = "User";

        public static string PROJECT = "Project";

        public static string ITEM = "Item";

        
    }
}
