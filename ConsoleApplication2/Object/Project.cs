using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Object
{
    class Project
    {

        public string name { get; }

        public string description { get; set; }

        //Table list and/or Item list
        public List<Item> items = new List<Item>();

    }
}
