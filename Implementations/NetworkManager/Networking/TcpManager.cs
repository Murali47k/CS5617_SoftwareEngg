using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class TcpManager : ICommunicator
    {
        protected int count = 0;
        public IMessageListener listener;
        public virtual void SendData(string addr, string data)
        {
            try
            {
                using TcpClient client = new TcpClient();
                client.Connect(addr, 5000);
                using StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(data);
                writer.Flush();

                Debug.WriteLine($"Sending data via TCP in LAN to {addr}");
                count++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to send data: {ex.Message}");
            }
        }

        public int GetCount() 
        { 
            return count;
        }

        public void Subscribe(IMessageListener l)
        {
            listener = l;
        }

        public void Listen(string addr)
        {
            Task.Run(() => ListentoData(addr));
        }

        public virtual void ListentoData(string addr)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse(addr), 5000);

            tcpListener.Start();

            Debug.WriteLine($"Listening on {addr}");

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                using StreamReader reader = new StreamReader(client.GetStream());

                string message = reader.ReadLine();


                if (listener != null)
                {
                    listener.OnMessageReceived(message);
                }

                client.Close();
            }
        }
    }
}
