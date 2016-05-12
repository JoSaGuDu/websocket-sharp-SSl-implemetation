using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketServer
{
    public class Print : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine("A new connection open");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved {0} at {1}", e.Data, DateTime.Now.ToString("hh:mm tt"));
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("Connection closed: {0}", e.Reason);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            Console.WriteLine("Error: {0}", e.Message);
        }
    }
}
