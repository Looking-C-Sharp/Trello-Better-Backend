using Sticky_Backend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sticky Backend Server";
            Console.WriteLine("Welcome to the Sticky backend!");
            doSomething();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();
        }

        private static void doSomething()
        {
            StickyController c = new StickyController();
            
            Console.WriteLine("Here's the result of a DB query: " + c.mutateList());
        }
    }
}
