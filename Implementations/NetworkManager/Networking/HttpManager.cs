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
    public class HttpManager : ICommunicator
    {

        private int count = 0;
        public IMessageListener listener;
        public virtual void SendData(string addr, string data)
        {
            Debug.WriteLine($"Sending data via HTTP in WIFI to {addr}");
            count++;
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

        public void ListentoData(string addr)
        {
            Debug.WriteLine($"Listening via HTTP on {addr}");

        }
    }
}
