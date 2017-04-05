using Sticky_Backend.DAL;
using Sticky_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sticky_Backend.Controllers
{
    public class StickyController
    {
        private StickyContext db = new StickyContext();

        public StickyController() { }

        public string mutateList()
        {
            /*
              User u = new User();
              u.name = "AErica";
              u.username = "Aerica" + DateTime.Now.Ticks;
              db.Users.Add(u);
              db.SaveChanges();
            */


            return FindGroupsOfUser("enclark").ElementAt(0).name;
            //return u.name;
        }

        public User login(string username, string password)
        {
            User u = db.Users.Find(username);
            if (u.passwordHash == (hashPassword(password)))
            {
                return u;
            }
            else
            {
                return null;
            }
        }

        //For purposes of populating the db for testing and
        //for demo purposes
        public User createUser(string username, string name, string password, string avatar)
        {
            User u = new User();
            u.name = name;
            u.username = username;
            u.passwordHash = password;
            u.avatar = avatar;
            db.Users.Add(u);
            db.SaveChanges();
            return u;
        }

        //Also for testing and demo purposes
        public Group createGroup(string name, string creator, List<string> members)
        {
            //groups start with no projects and no chat
            Group g = new Group();
            g.name = name;
            g.creator = db.Users.Find(creator);
            g.administrators = new List<User>();
            g.members = new List<User>();
            g.administrators.Add(g.creator);
            foreach (string username in members)
            {
                User member = db.Users.Find(username);
                if (member != null)
                {
                    g.members.Add(member);
                }
            }
            db.Groups.Add(g);
            db.SaveChanges();

            return g;

        }

        public List<Group> FindGroupsOfUser(string username)
        {
            User u = db.Users.Find(username);
            return db.Groups.Where(g => g.creator.username == u.username).ToList();

            /*.Select(g => new Group
        {
            ID = g.ID,
            name = g.name,
            creator = g.creator,
            administrators = g.administrators,
            members = g.members,
            chat = g.chat,
            projects = g.projects
        }).ToList();
        */
        }

        public static string hashPassword(string password)
        {
            return password; //just return it for now
        }
    }
}
