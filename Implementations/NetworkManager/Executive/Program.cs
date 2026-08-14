using Networking;

namespace Executive
{
    internal class Program
    {
        class Listener : IMessageListener
        {
            public void OnMessageReceived(string message)
            {
                Console.WriteLine($"Message received : {message}");
            }
        }

        static void Main(string[] args)
        {
            NetworkFactory factory = new NetworkFactory();
            Listener listener = new Listener();

            //ICommunicator communicator = factory.Communicator("WIFI");
            ICommunicator communicator = factory.Communicator("LAN");
            communicator.Subscribe(listener);
            communicator.SendData("192.168.1.100", "Hello World!");

            Console.WriteLine($"Message sent : {communicator.GetCount()}");
        }
    }
}
