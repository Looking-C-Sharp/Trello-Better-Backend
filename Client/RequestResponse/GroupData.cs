using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequestResponse
{
    public class GroupData
    {

        public string creator { get; set; } //creator's id

        public List<string> newUsers { get; set; } = new List<string>(); //users' usernames

        public List<string> removeUsers { get; set; } = new List<string>(); //users' usernames

        //chat not added yet

    }
}
