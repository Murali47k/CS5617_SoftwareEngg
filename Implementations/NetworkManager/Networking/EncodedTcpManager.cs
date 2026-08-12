using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class EncodedTcpManager : TcpManager
    {

        public override void SendData(string addr, string data)
        {
            string encodedData = Encoder(data);

            Debug.WriteLine($"Encoded Data: {encodedData}");

            Debug.WriteLine(
                $"Sending encoded data via TCP in LAN to {addr}"
            );
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
