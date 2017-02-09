using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Models
{
    class User
    {
        [Key]
        public string username { get; set; }
        public string avatar { get; set; }
        public string name { get; set; }
        public string passwordHash { get; set; }
    }
}
