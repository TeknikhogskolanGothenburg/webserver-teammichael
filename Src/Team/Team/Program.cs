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
using webserver;

namespace WebServer
{
    class Program


    {

        static void Main(string[] args)

        {

            Console.WriteLine("Starting seever om the port 8080 ");
            HTTPServer server = new HTTPServer(8080);

            server.start();


        }


    }

}

