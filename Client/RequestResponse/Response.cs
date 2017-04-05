using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sticky_Backend.Models;

namespace RequestResponse
{
    public class Response
    {
        public string id { get; set; }

        public bool logoff { get; set; }

        public bool success { get; set; }

        public string groupId { get; set; }

        public List<string> sendTo { get; set; } = new List<string>(); //List of ids

        public User userdata = new User();

        public List<Group> groupData { get; set; } = new List<Group>();

        public List<Project> projectData { get; set; } = new List<Project>();

    }
}
