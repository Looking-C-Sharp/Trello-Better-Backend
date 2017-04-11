using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Backend.Controllers
{
    class UserController
    {
        /// <summary>
        /// Validates a user's credentials.
        /// </summary>
        /// <param name="username">The username, the primay key.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>True if the user account info is valid.</returns>
        public static bool Validate(string username, string password)
        {
            // TODO: stub
            Random r = new Random();
            return r.Next() % 2 == 0;
        }

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="username">The username primary key.</param>
        /// <param name="avatar">The email address to locate a gravatar.</param>
        /// <param name="name">The legal (or illegal) name for the user.</param>
        /// <param name="password">The user's desired password.</param>
        /// <returns>True if the user was created.</returns>
        public static bool CreateUser(string username, string avatar, string name, string password)
        {
            // TODO: stub
            Random r = new Random();
            return r.Next() % 2 == 0;
        }
    }
}
