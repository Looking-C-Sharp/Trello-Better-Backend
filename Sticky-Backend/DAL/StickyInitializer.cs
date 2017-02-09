using Sticky_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.DAL
{
    class StickyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StickyContext>
    {
        protected override void Seed(StickyContext context)
        {
            var lists = new List<List>
            {
                new List{title="List 1"},
                new List{title="List 2"}
            };

            //lists.ForEach(s => context.Lists.Add(s));
            context.SaveChanges();
        }
    }
}
