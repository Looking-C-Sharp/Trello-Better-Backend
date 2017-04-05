using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Messaging;
using Newtonsoft.Json;
using RequestResponse;
using System.IO;

namespace Runnable
{
    public class Responder
    {

        public StreamWriter streamWriter { get; set; }

        public bool exit { get; set; } //Note: This isn't really working to stop the thread

        public MessageQueue mq;

        public int id { get; set; }

        public void listen()
        {
            try
            {
                mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                while (!exit)
                {
                    Message message = mq.Receive();
                    streamWriter.WriteLine(message.Body);
                    Debug.WriteLine("Responder: " + message.Body);
                    streamWriter.Flush();
                    Response res = JsonConvert.DeserializeObject<Response>((string)message.Body);
                    if (res.logoff)
                    {
                        break;
                    }
                }
                streamWriter.Close();
                Debug.WriteLine("Responder Closed");
            }catch(Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
