using System;
using WebSocketSharp;

namespace WebsocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Websocket Client";
                using (var ws = new WebSocket("wss://127.0.0.1:8551/Print"))
                {
                    ws.Connect();
                    Console.WriteLine("Connected to server");
                    while (true)
                    {
                        Console.Write("Send something: ");
                        var data = Console.ReadLine();
                        ws.Send(data);
                        Console.WriteLine("Sent {0} at {1}\n", data, DateTime.Now.ToString("hh:mm tt"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}
