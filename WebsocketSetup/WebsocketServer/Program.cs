using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
using System.Configuration;

namespace WebsocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Title = string.Format("Server: {0}, Port: {1}, IsSecure: {2}", ServerModel.Server, ServerModel.Port,
                                              ServerModel.IsSsl);

                var server = new WebSocketServer(IPAddress.Parse(ServerModel.Server), ServerModel.Port, ServerModel.IsSsl);
                if (server.IsSecure)
                {
                    Console.WriteLine("Signing certificate...");
                    server.SslConfiguration = new ServerSslConfiguration(GetCesrtificate());
                }
                server.AddWebSocketService<Print>("/Print");
                server.Start();
                Console.Clear();
                Console.WriteLine("\nServer Started\n\nServer: {0}\nPort: {1}\nIs secure: {2}\n\n", ServerModel.Server, server.Port, server.IsSecure);

                Console.WriteLine("Press escape to stop the server");
                while (true)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                        break;
                }
                server.Stop();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        static X509Certificate2 GetCesrtificate()
        {
            var certPath = ConfigurationManager.AppSettings["CertPath"].Trim();
            var certPass = ConfigurationManager.AppSettings["CertPass"].Trim();
            return new X509Certificate2(certPath, certPass);
        }
    }
}
