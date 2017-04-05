using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Messaging;
using Newtonsoft.Json;
using RequestResponse;
using System.IO;
using Queue;


namespace Runnable
{
    class Listener
    {

        private Socket socketForClient;

        private MessageQueue mainMQ;

        private MessageQueue userMQ;

        public int id { get; set; }

        public Listener(Socket socket)
        {
            socketForClient = socket;

            if (!MessageQueue.Exists(@".\private$\main"))
            {
                MessageQueue.Create(@".\private$\main");
            }
            mainMQ = new MessageQueue(@".\private$\main");
        }

        public void listen()
        {

            if (socketForClient.Connected)
            {
                Debug.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                Responder responder = new Responder();
                responder.streamWriter = new System.IO.StreamWriter(networkStream);

                MessageQueueHolder mqh = MessageQueueHolderFactory.GetMessageQueueHolder();
                responder.mq = mqh.NewQueue(id + "");

                //First, give the client the id
                Debug.WriteLine(id);
                responder.streamWriter.WriteLine(id + "");
                responder.streamWriter.Flush();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);

                Thread thread = new Thread(responder.listen);
                thread.Start();
                /*
                                //Login/signup User
                                Request r = null;
                                while (r == null)
                                {
                                    string msg = streamReader.ReadLine();
                                    r = ParseMessage(msg);
                                }
                */

                while (true)
                {
                    //Once the user is logged in, just listen for requests and return responses
                    try
                    {
                        string msg = streamReader.ReadLine();

                        if (msg != null)
                        {
                            Request r = ParseMessage(msg);
                            
                            if (r.logoff)
                            {
                                responder.exit = true;
                                break;
                            }
                            mainMQ.Send(msg, "Title");
                        }
                    }
                    catch (IOException e)
                    {
                        //Should catch if there is an exception like the user unexpectedly disconnected, adn should kill the thread
                        Debug.WriteLine(e.StackTrace);
                        break;
                    }

                }
                mainMQ.Purge();
                mainMQ.Close();
                streamReader.Close();
                networkStream.Close();

            }
            socketForClient.Close();
            Debug.WriteLine("Listener Ended");
        }

        public Request ParseMessage(string msg)
        {
            if (msg != null)
            {
                Request request = JsonConvert.DeserializeObject<Request>(msg);
                Debug.WriteLine(request.type);
                return request;
            }
            else return null;
        }
    }
}
