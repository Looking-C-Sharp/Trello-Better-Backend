using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Messaging;
using System.IO;
using RequestResponse;
using System.Diagnostics;
using Newtonsoft.Json;
using Sticky_Backend.Models;

namespace ClientRunnable
{
    class ClientListener
    {
        public string id { get; set; }

        //Will recieve the messages to send through this queue
        public MessageQueue mq;

        public string mqName { get; }

        public StreamWriter streamWriter { get; set; }

        public ClientListener(string name)
        {
            mqName = name;
            if (!MessageQueue.Exists(@".\private$\" + mqName))
            {
                MessageQueue.Create(@".\private$\" + mqName);
            }
            mq = new MessageQueue(@".\private$\" + mqName);
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        }

        public void listen()
        {
            Request req = new Request();
            req.login = true;
            req.type = Request.GET;
            req.target = Request.USER;
            req.userData = new User();
            req.userData.name = "Erica";
            req.userData.username = "enclark";
            req.userData.passwordHash = "Ilovedogs";
            req.id = id;
            Console.WriteLine(id);
            streamWriter.WriteLine(JsonConvert.SerializeObject(req));
            streamWriter.Flush(); ;
            while (true)
            {
                System.Messaging.Message m = mq.Receive();
                if (m != null && m.Body != null)
                {

                    streamWriter.WriteLine(m.Body);
                    streamWriter.Flush();
                }
            }
        }

        public Request ParseMessage(string msg)
        {
            Debug.WriteLine(msg);
            Request request = JsonConvert.DeserializeObject<Request>(msg);
            return request;
        }
    }
}
