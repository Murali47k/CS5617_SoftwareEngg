using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class HttpManager : ICommunicator
    {
        
         private int count = 0;
         public virtual void SendData(string addr, string data)
          {
             Console.WriteLine($"Sending data : {data} via HTTP in the Internet to {addr}");
             count++;
          }

         public int GetCount()
         {
             return count;
         }
       
    }
}
