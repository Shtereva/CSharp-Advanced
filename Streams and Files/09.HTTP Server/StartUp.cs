using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _09.HTTP_Server
{
    public class StartUp
    {
        public static void Main()
        {
            var portNumber = 8081;
            var tcpListener = new TcpListener(IPAddress.Any, portNumber);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", portNumber);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];

                    int readedBytes = stream.Read(request, 0, request.Length);

                    string req = Encoding.UTF8.GetString(request, 0, readedBytes);

                    Console.WriteLine(req);

                    if (string.IsNullOrEmpty(req))
                    {
                        continue;
                    }

                    string path = req.Split()[1];

                    var html = string.Empty;
                    if (path == "/")
                    {
                        html = File.ReadAllText(@"../files/index.html");
                    }
                    else if (path == "/info")
                    {
                        html = string.Format(File.ReadAllText(@"../files/info.html"), $"{DateTime.Now:dd/MM/yy HH:mm:ss}", Environment.ProcessorCount);
                    }
                    else
                    {
                        html = File.ReadAllText(@"../files/error.html");
                    }

                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("HTTP 200 Ok\n\r\n\r" + html);
                    }
                }
            }
        }
    }
}
