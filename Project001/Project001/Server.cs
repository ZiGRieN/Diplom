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
        
        public Server(int port)
        {          
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            //form.sost_serv = getSost();
            ThreadPool.SetMaxThreads(4,4);
            ThreadPool.SetMinThreads(1,1);
            while (true)
            {
                thread = new Thread(ClientThread);

                thread.Start(listener.AcceptTcpClient());
            }

        }

        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient)StateInfo);
        }

        public string getSost()
        {
            var s = "Сервер запущен";
            return s;  
        }
    }
}
