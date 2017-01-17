using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Project001
{
    class Server
    {

    Thread thread;
        
        public void StartServer(int port)
        {
            
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            ThreadPool.SetMaxThreads(4,4);
            ThreadPool.SetMinThreads(1,1);
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                thread = new Thread(new ParameterizedThreadStart(ClientThread));
                thread.Start(client);
            }

        }

        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient)StateInfo);
        }
    }
}
