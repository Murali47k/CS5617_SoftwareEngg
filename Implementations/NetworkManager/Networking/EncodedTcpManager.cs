using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class EncodedTcpManager : TcpManager
    {
        private int count = 0;

        public override void SendData(string addr, string data)
        {
            string encodedData = Encoder(data);
            Console.WriteLine($"Encoded Data : {encodedData}");

            string decodedData = Decoder(encodedData);
            Console.WriteLine($"Sending data : {decodedData} via TCP in LAN to {addr} with Encoding and Decoding");
            count++;
        }

        private string Encoder(string data)
        {
            if (data == null)
            {
                return "No data";
            }

            byte[] bytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(bytes);
        }

        private string Decoder(string encodedData)
        {
            if (encodedData == null)
            {
                return "Invalid encoded Data";
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(encodedData);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (FormatException)
            {
                return "Invalid encoded Data";
            }
        }
    }
}
