using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class TcpManager : ICommunicator
    {
        private int count = 0;
        public virtual void SendData(string addr,string data)
        {
            Console.WriteLine($"Sending data : {data} via TCP in LAN to {addr}");
            count++;
        }

        public int GetCount() 
        { 
            return count;
        }
    }
}
