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

        public string first()
        {
            return db.Lists.First<List>().title;
        }
    }
}
