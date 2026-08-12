using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine($"Sending data via HTTP in WIFI to {addr}");
            count++;
          }

         public int GetCount()
         {
             return count;
         }
       
    }
}
