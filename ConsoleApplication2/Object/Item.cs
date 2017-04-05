using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Object
{
    class Item
    {
        public string title { get; set; }

        public string description { get; set; }

        public string[] attachments { get; set; }

        public string assignee { get; set; } //the id of the assigned person

        public string history { get; set; }

        public Int64 created { get; set; }

        public Int64 lastModified { get; set; }
    }
}
