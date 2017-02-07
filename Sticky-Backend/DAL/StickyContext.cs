using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sticky_Backend.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sticky_Backend.DAL
{
    class StickyContext : DbContext
    {
        public StickyContext() : base("StickyContext")
        {
        }

        public DbSet<List> Lists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
