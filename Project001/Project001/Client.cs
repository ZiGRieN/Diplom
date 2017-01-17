using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Project001
{
    class Client
    {
        public Client(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint);
        }
    }
}
