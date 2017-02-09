using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    class Message
    {
        public int ID { get; set; }
        public User author { get; set; }
        public string body { get; set; }
        public List<string> attachments { get; set; }
        public List<Emoji> emoji { get; set; }
    }
}
