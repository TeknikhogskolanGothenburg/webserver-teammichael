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

    public class Request

    {



        public string Type { get; set; }
        public string URL { get; set; }
        public string Host { get; set; }
        public string Referer { get; set; }


        private Request(String type, string url, string host, string referer)

        {
            Type = type;
            URL = url;
            Host = host;
            Referer = referer;
        }


        public static Request GetRequest(string request)

        {
            char z = '/';
            if (string.IsNullOrEmpty(request))
                return null;

            string[] tokens = request.Split(z);

            string type = tokens[0];
            string url = tokens[1];
            string host = tokens[4];
            string referer = "";
            for (int i = 0; i < tokens.Length; i++)

            {
                if (tokens[i] == " Referer")
                {
                    referer = tokens[i + 1];
                    break;
                }
            }
            return new Request(type, url, host, referer);
        }









    }
}
