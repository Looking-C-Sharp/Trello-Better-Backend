using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Controllers
{
    class UserController
    {
        public static bool Validate(string username, string password)
        {
            // TODO: stub
            Random r = new Random();
            return r.Next() % 2 == 0;
        }
    }
}
