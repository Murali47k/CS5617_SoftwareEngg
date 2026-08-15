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

            ICommunicator communicator = factory.Communicator("WIFI");
            //ICommunicator communicator = factory.Communicator("LAN");
            communicator.Subscribe(listener);

            string addr = "127.0.0.1";
            communicator.Listen(addr);
            Thread.Sleep(500); 
            // give the listener time to start before sending

            communicator.SendData(addr, "Hello World!");
            Thread.Sleep(500); 
            // give the listener time to receive before checking count

            Console.WriteLine($"Total count : {communicator.GetCount()}");
        }
    }
}
