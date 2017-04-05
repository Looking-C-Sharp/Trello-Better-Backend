using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Client.ClientRunnable
{
    class Receiver
    {
        public StreamReader streamReader { get; set; }

        public string id { get; set; }

        //This will need to write to a message queue
        //And it needs to end sometime
        public void listen()
        {
            
            while (true)
            {
                string msg = streamReader.ReadLine();
                Debug.WriteLine("Receiver: " + msg);
                Console.WriteLine(msg); //Normally would only write to message queue
            }
            
        }
    }
}
