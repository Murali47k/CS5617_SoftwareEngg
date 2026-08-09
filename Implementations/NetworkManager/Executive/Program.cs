using Networking;

namespace Executive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetworkFactory factory = new NetworkFactory();

            //ICommunicator communicator = factory.Communicator("LAN");
            ICommunicator communicator = factory.Communicator("WIFI");

            communicator.SendData("192.168.1.800", "Hello World!");

            Console.WriteLine($"Message sent : {communicator.GetCount()}");
        }
    }
}
