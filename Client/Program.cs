using System;
using System.Net.Sockets;
using System.Threading;
using RequestResponse;
using Newtonsoft.Json;
using System.Diagnostics;
using ClientRunnable;

namespace Client
{

    public class Client
    {
        static public void Main(string[] Args)
        {
            TcpClient socketForServer;
            try
            {
                socketForServer = new TcpClient("localHost", 8080);
            }
            catch
            {
                Console.WriteLine(
                "Failed to connect to server at {0}:8080", "localhost");
                Console.WriteLine("Press any key to exit from client program");
                Console.ReadKey();
                return;
            }

            NetworkStream networkStream = socketForServer.GetStream();
            //System.IO.StreamReader streamReader =
            //new System.IO.StreamReader(networkStream);
            //System.IO.StreamWriter streamWriter =
            //new System.IO.StreamWriter(networkStream);
            Console.WriteLine("*******This is client program who is connected to localhost on port No:10*****");

            ClientListener listener = new ClientListener("enclark");
            ClientRunnable.Receiver receiver = new ClientRunnable.Receiver();
            try
            {
                // read the data from the host and display it
                {
                    //outputString = streamReader.ReadLine();
                    //Console.WriteLine("Message Recieved by server:" + outputString);

                    //Console.WriteLine("Type your message to be recieved by server:");

                    ///////////////////
                    
                    
                    listener.streamWriter = new System.IO.StreamWriter(networkStream);
                    receiver.streamReader = new System.IO.StreamReader(networkStream);
                    
                    string id = receiver.streamReader.ReadLine();
                    listener.id = id;
                    receiver.id = id;
                    Thread thread1 = new Thread(listener.listen);
                    Thread thread2 = new Thread(receiver.listen);
                    thread1.Start();
                    thread2.Start();
                    ///////////////////

                    /*
                    Request r = new Request();
                    r.type = "GET";
                    r.userData = new UserData();
                    r.userData.username = "enclark";

                    string json = JsonConvert.SerializeObject(r);
                    Console.WriteLine(json);

                    Console.WriteLine("type:");
                    string str = Console.ReadLine();
                    while (str != "exit")
                    {
                        streamWriter.WriteLine(json);
                        streamWriter.Flush();
                        string resp = streamReader.ReadLine();
                        Debug.WriteLine("Client: " + resp);
                        Response res = JsonConvert.DeserializeObject<Response>(resp);
                        Console.WriteLine(resp + " " + res.success);
                        Console.WriteLine("type:");
                        str = Console.ReadLine();
                    }
                  
                    if (str == "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();

                    }
                    */
                }
            }
            catch
            {
                Console.WriteLine("Exception reading from Server");

            }
            // tidy up
            
            Console.WriteLine("Press any key to exit from client program");
            Console.ReadKey();
            //receiver.streamReader.Close();
            //listener.streamWriter.Close();
            networkStream.Close();
        }

    }
}