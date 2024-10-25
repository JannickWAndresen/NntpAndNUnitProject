using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NntpAndUnitProject
{
    public class ConnectionModel
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ConnectionModel(string server, int port, string username, string password)
        {
            Server = server;
            Port = port;
            Username = username;
            Password = password;
        }
    }
}
