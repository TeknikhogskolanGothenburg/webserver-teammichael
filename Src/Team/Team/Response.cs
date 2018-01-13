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
    public class Response
    {

        private Byte[] data = null;
        private string status;
        private string mime;  // 6 minut v2

        private Response(string status, string mime, Byte[] data)


        {
            this.status = status;
            this.data = data;
            this.mime = mime;

        }

        public static Response From(Request request)


        {
            if (request == null)
                return MakeNullRequest();

            if (request.Type == "GET")

            {
                string file = Environment.CurrentDirectory + HTTPServer.WEB_DIR + request.URL;

                FileInfo f = new FileInfo(file);

                if (f.Exists && f.Extension.Contains("."))
                {

                    return MakeFromFile(f);
                }

                else
                {
                    DirectoryInfo di = new DirectoryInfo(f + "/");

                    if (!di.Exists)
                        return MakePageNotFound();

                    FileInfo[] files = di.GetFiles();


                    foreach (FileInfo ff in files)

                    {
                        string n = ff.Name;
                        if (n.Contains("default.html") || n.Contains("default.htm") ||
                        n.Contains("index.html") || n.Contains("index.htm"))
                            return MakeFromFile(ff);

                    }
                }

            }

            else


                return MakeMethodNotAllowed();
            return MakePageNotFound();

        }

        private static Response MakeFromFile(FileInfo f)


        {
            string file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            FileInfo fi = new FileInfo(file);
            FileStream fs = f.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response(" 200 ok request  ", "html\text", d);

        }






        private static Response MakeNullRequest()

        {
            string file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "400.html";
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response(" 400 bad request", "html\text", d);

        }


        private static Response MakeMethodNotAllowed()

        {
            string file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "405.html";
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response(" 405 not allowed  ", "html\text", d);

        }

        private static Response MakePageNotFound()

        {
            string file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + "404.html";
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            fs.Close();
            return new Response(" 405 not Found", "html\text", d);

        }

        public void Post(NetworkStream stream)

        {

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(string.Format("{0}  {1}\r\nServer: {2}\r\nContent=Type: {3}\r\nAccept=Ranges:bytes\r\nContent= Length : {4}\r\n",
                HTTPServer.VERSION, status, HTTPServer.Name, mime, data.Length));

            stream.Write(data, 0, data.Length);
        }


    }
}
