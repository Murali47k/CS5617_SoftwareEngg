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
    public class EncodedTcpManager : TcpManager
    {

        public override void SendData(string addr, string data)
        {
            string encodedData = Encoder(data);

            try
            {
                using TcpClient client = new TcpClient();
                client.Connect(addr, 5000);
                using StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(encodedData);
                writer.Flush();

                Debug.WriteLine($"Sending encoded data via TCP in LAN to {addr}");
                Debug.WriteLine($"Encoded data: {encodedData}");
                count++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to send data: {ex.Message}");
            }
        }

        public override void ListentoData(string addr)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse(addr), 5000);

            tcpListener.Start();

            Debug.WriteLine($"Listening on {addr}");

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                using StreamReader reader = new StreamReader(client.GetStream());

                string encodedMessage = reader.ReadLine();
                string message = Decoder(encodedMessage);

                if (listener != null)
                {
                    listener.OnMessageReceived(message);
                }

                client.Close();
            }
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
