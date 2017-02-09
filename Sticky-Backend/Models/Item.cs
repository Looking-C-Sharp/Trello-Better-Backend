using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    class Item
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<String> attachments { get; set; }
        public User assignee { get; set; }
        public string history { get; set; }
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }
        public List<Comment> comments { get; set; }
        public List<Emoji> emoji { get; set; }
    }
}
