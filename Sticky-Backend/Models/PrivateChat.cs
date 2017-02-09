using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    class PrivateChat
    {
        public int ID { get; set; }
        public List<User> members { get; set; }
        public List<Message> messages { get; set; }
    }
}
