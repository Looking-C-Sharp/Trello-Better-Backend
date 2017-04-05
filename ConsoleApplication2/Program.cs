using System.Net;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Messaging;
using Runnable;


public class Server
{
    static Int32 port = 8080;
    static IPAddress localAddr = IPAddress.Parse("127.0.0.1");
    public static TcpListener server = new TcpListener(localAddr, port);

    public static void Main()
    {

        server = new TcpListener(localAddr, port);
        server.Start();

        MessageQueue mq = new MessageQueue(@".\private$\main");
        mq.Purge();

        //I'm in a rush, sorry this is not cryptographically secure
        Random rando = new Random();

        MainListener mainListener = new MainListener();
        Thread mainThread = new Thread(new ThreadStart(mainListener.listen));
        mainThread.Start();

        Debug.WriteLine("************This is Server program************");
        while (true)
        {
            Socket socketForClient = Server.server.AcceptSocket();

            Debug.WriteLine("Client Accepted");


            Listener listener = new Listener(socketForClient);
            listener.id = rando.Next();
            Thread newThread = new Thread(new ThreadStart(listener.listen));
            newThread.Start();
        }
    }

}
