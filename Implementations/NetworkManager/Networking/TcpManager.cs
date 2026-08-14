using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class TcpManager : ICommunicator
    {
        protected int count = 0;
        public IMessageListener listener;
        public virtual void SendData(string addr,string data)
        {
            Debug.WriteLine($"Sending data via TCP in LAN to {addr}");
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
            //new Task(() => ListentoData(addr).Start());
            // Yet to implement the listening functionality
        }

        public void ListentoData()
        {
            // yet to implement the listening functionality
        }
    }
}
