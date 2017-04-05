using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public User author { get; set; }
        public string body { get; set; }
        public DateTime date { get; set; }
    }
}
