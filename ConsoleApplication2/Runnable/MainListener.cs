using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Messaging;
using Newtonsoft.Json;
using RequestResponse;
using Object;
using Queue;
using Sticky_Backend.Controllers;

namespace Runnable
{
    public class MainListener
    {

        private MessageQueueHolder mqh = MessageQueueHolderFactory.GetMessageQueueHolder();

        private Groups onlineGroups = new Groups();

        private Users onlineUsers = new Users();

        private MessageQueue main;

        private StickyController controller = new StickyController();

        public void listen()
        {
            main = new MessageQueue(mqh.main);
            main.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            while (true)
            {
                Message m = main.Receive();
                if (m != null)
                {
                    string msg = (string)m.Body;

                    Debug.WriteLine("Main: " + msg);

                    if (msg == "exit")
                    {
                        break;
                    }

                    Request req = ParseMessage(msg);
                    Response res = ProcessMessage(req);
                    Notify(res);
                }
            }
            //Clear out the message Queue just in case
            main.Purge();
            Debug.WriteLine("Main Ended");
        }

        public Request ParseMessage(string msg)
        {
            Debug.WriteLine(msg);
            Request request = JsonConvert.DeserializeObject<Request>(msg);
            return request;
        }

        public Response ProcessMessage(Request req)
        {
            Response res = new Response();
            res.success = true;
            if (req.type == Request.GET)
            {
                RetreiveObject(req, res);
            }
            else if (req.type == Request.POST)
            {
                CreateObject(req, res);
            }
            else if (req.type == Request.PUT)
            {
                UpdateObject(req, res);
            }
            else if (req.type == Request.DELETE)
            {
                //Do this last, this is the least important
                DeleteObject(req, res);
            }

            //if failed only send message to current user, otherwise send all affected (if project or group notify whole group)
            return res;
        }


        private void RetreiveObject(Request req, Response res)
        {
            if (req.target == Request.USER)
            {
                if (req.login)
                {
                    //create new user object and retrieve user from database to populate it
                    Sticky_Backend.Models.User user = controller.login(req.userData.username, req.userData.passwordHash);
                    if(user != null)
                    {
                        onlineUsers.AddUser(user, req.id);
                        //Also create whatever groups they are in that are not already created and retrieve all data
                        List<Sticky_Backend.Models.Group> groupsToAdd = controller.FindGroupsOfUser(user.username);
                        foreach (Sticky_Backend.Models.Group group in groupsToAdd)
                        {
                            onlineGroups.AddGroup(group);
                            res.groupData.Add(group);
                        }
                        //Respond with user data and their group/project data
                        Debug.WriteLine("OnlineGroups: " + onlineGroups);
                        Debug.WriteLine("OnlineUsers: " + onlineUsers);
                        //Send only to individual user
                        res.sendTo.Add(req.userData.username);
                    }
                }
                else
                {
                    res.success = false;
                    //Query for user data and put it in the response object
                    //return success if successful
                }
            }
            else if (req.target == Request.GROUP)
            {
                //return the information of the group. Including the projects
                //return success if successful
            }
            else if (req.target == Request.PROJECT)
            {
                //return the information of the group. Including the projects
                //return success if successful
            }
        }

        private void CreateObject(Request req, Response res)
        {
            if (req.target == Request.USER)
            {
                if (req.login)
                {
                    //Add User to the database
                    //create new user object and retrieve user from database to populate it
                    //Also create whatever groups they are in that are not already created and retrieve all data
                    //Respond with user data and their group/project data
                    //return success if successful
                }
                else
                {
                    //Add user to the database
                    //But they are not online, this should not be used too much in practice
                    //return success if successful
                }
            }
            if (req.target == Request.GROUP)
            {
                //create new group in database.  If any of the new users are online, they should be added to the group's active users
                //notify each new group member in response
                //return success if successful
            }
            if (req.target == Request.PROJECT)
            {
                //group id must be specified. Create new project under that group in the database, then return success, notify each online member
                //of the new updates
            }
        }

        public void UpdateObject(Request req, Response res)
        {
            if (req.target == Request.USER)
            {
                //Make sure the two 
            }
            if (req.target == Request.GROUP)
            {
                //Check if sentBy is the creator of the group, if not, they do not have access edit to the group
                //If they are, update the group in the database, and memory.  Add new users to the active user group and send out responses 
                //to each online group member with the updates
            }
            if (req.target == Request.PROJECT)
            {
                //group id must be specified. Create new project under that group in the database, update each online member in the group.
            }
        }

        public void DeleteObject(Request req, Response res)
        {
            if (req.target == Request.USER)
            {
                //Make sure the two ids match, then destroy user, close threads
            }
            if (req.target == Request.GROUP)
            {
                //update group database, notify each online member then unsub them, and destroy object
            }
            if (req.target == Request.PROJECT)
            {
                //update database, notify each online member then unsub them, and destroy object
            }
        }

        public void Notify(Response res)
        {
            List<string> usernames = res.sendTo;
            foreach(string username in usernames)
            {
                string id = onlineUsers.GetId(username);
                MessageQueue mq = mqh.GetUserQueue(id);
                if(mq != null)
                {
                    mq.Send(JsonConvert.SerializeObject(res));
                } 
                
            }
        }
    }
}
