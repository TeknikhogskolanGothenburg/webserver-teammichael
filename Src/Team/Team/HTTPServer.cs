using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace webserver 
{
     
     public class HTTPServer

    {



        public const string MSG_DIR = "/root/msg/";
        public const string WEB_DIR = "/root/web/"; // v2 10 m
        public const string VERSION = "HTTP/1.1";
        public const string Name = "vshost32.exe";


        private bool running = false;
        private TcpListener listner;

        public HTTPServer(int port)

        {
            listner = new TcpListener(System.Net.IPAddress.Any, port);
        }


        //Oreferences 

        public void start()

        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start();


        }

        //1 references 


        private void Run()

        {
            running = true;
            listner.Start();

            while (running)
            {
                Console.WriteLine(" Waiting for the connection ");
                TcpClient client = listner.AcceptTcpClient();

                Console.WriteLine(" Client  Connnected");


                //HandleClient(client);
                HandleClient(client);
                client.Close();
            }
            running = false;
            listner.Stop();

        }


        /// 1 reference 

        private void HandleClient(TcpClient Client)


        {
            StreamReader reader = new StreamReader(Client.GetStream())
            ;

            String msg = "";

            while (reader.Peek() != -1)

            {
                msg += reader.ReadLine() + "\n";
            }

            //Debug.

            Debug.WriteLine(" Request : \n" + msg);
            Console.WriteLine("Request: \n" + msg);
            Request req = Request.GetRequest(msg);
            Response resp = Response.From(req);
            resp.Post(Client.GetStream());
        }

    }
}
