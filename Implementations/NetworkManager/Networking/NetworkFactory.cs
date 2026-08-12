using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class NetworkFactory
    {
        public ICommunicator Communicator(string type) 
        {
            if (type == "LAN")
            {
                return new EncodedTcpManager();
            }
            else if (type == "WIFI")
            {
                return new HttpManager();
            }
            else
            {
                throw new ArgumentException(
                    $"Unsupported communication type: {type}",
                    nameof(type)
                );
            }
            

        }
    }
}
