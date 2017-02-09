using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    class Project
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<List> lists { get; set; }
        public List<Message> messageBoard { get; set; }
    }
}
