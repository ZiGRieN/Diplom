using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project001
{
    public partial class Form1 : Form
    {
        public TcpListener listener;
        private Thread listenerThread;
        private TcpClient client;
        private int port;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port = int.Parse(portTB.Text);
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
            listener.Start();
            listenerThread = new Thread(new ThreadStart(Listener));
            listenerThread.Start();
            label2.Text = label2.Text + " сервер запущен";
        }
        private void Listener()
        {

            while (true)
            {
                client = listener.AcceptTcpClient();
                Thread Thread = new Thread(ClientThread);
                Thread.Start(client);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), listener.AcceptTcpClient());
            }
        }
        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient)StateInfo);
        }
    }

}
