using System;
using System.Configuration;

namespace WebsocketServer
{
    public class ServerModel
    {
        private static string _server;
        private static int _port;
        private static bool? _isSsl;

        public static string Server
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_server))
                {
                    _server = ConfigurationManager.AppSettings["Server"] != null
                                  ? ConfigurationManager.AppSettings["Server"].Trim()
                                  : "127.0.0.1";
                }
                return _server;
            }
        }

        public static int Port
        {
            get
            {
                if (_port == 0)
                {
                    var port = ConfigurationManager.AppSettings["Port"] != null
                                  ? ConfigurationManager.AppSettings["Port"].Trim()
                                  : "8080";
                    _port = Convert.ToInt32(port);
                }
                return _port;
            }
        }

        public static bool IsSsl
        {
            get
            {
                if (!_isSsl.HasValue)
                {
                    var isssl = ConfigurationManager.AppSettings["IsSsl"] != null
                                  ? ConfigurationManager.AppSettings["IsSsl"].Trim()
                                  : "false";
                    _isSsl = Convert.ToBoolean(isssl);
                }
                return _isSsl.Value;
            }
        }
    }
}
