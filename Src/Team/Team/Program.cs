using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO; 

namespace WebServer
{
    class Program
    {
        static void Main()

        {
            GetFiles();
        }



        private static void server(string[] prifixes)


        {

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prifixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prifixes == null || prifixes.Length == 0)
                throw new ArgumentException("prifixes");



            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prifixes.
            foreach (string s in prifixes)
            {
                listener.Prefixes.Add(s);
                Console.WriteLine("Listening..." + s );

            }

            while (true)

            {

                listener.Start();
              //  Console.WriteLine("Listening..." + );


                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.


                HttpListenerResponse response = context.Response;
                // Construct a response.


                //string responseString = File.ReadAllText(");




                //////      string responseString"<HTML><BODY> Hello world!</BODY></HTML>";


                byte[] buffer = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/" + "Content" + request.RawUrl);


               
                //    //System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                //You must close the output stream.
                output.Close();
                listener.Stop();

            }
        }

        

        private static void GetFiles()

        {
            string[] fileEntries = Directory.GetFiles("Content", "*", SearchOption.AllDirectories);

            string[] url = new string[fileEntries.Length];

            //foreach (string x in url )

            //{

            //    Console.WriteLine(x);
            //}




            for (int i = 0; i < fileEntries.Length; i++)

            {

                url[i] = "http://localhost:8080/" + fileEntries[i].Substring("Content".Length + 1).Replace('\\', '/') + "/";
                
            }

            server(url);

        }

    }

}

