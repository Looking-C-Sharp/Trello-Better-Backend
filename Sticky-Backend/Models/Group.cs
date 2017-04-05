using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string name { get; set; }
        public User creator { get; set; }
        public List<User> administrators { get; set; }
        public List<User> members { get; set; }
        public List<Message> chat { get; set; }
        public List<Project> projects { get; set; }
    }
}
