using Sticky_Backend.DAL;
using Sticky_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Controllers
{
    class StickyController
    {
        private StickyContext db = new StickyContext();

        public string mutateList()
        {
            
            User u = new User();
            u.name = "Bob";
            u.username = "bob" + DateTime.Now.Ticks;
            db.Users.Add(u);
            db.SaveChanges();
            return db.Users.First().name;
        }
    }
}
