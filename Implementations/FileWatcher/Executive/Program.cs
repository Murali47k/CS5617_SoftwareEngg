using FileWatcher;

namespace Executive
{
    class Listener : IFileListener
    {
        public void OnFileChanged(string content)
        {
            Console.WriteLine("Updated File Content :");
            Console.WriteLine($"{content}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IFileConnector communicator = new FileReader("C:\\Users\\Hp\\source\\repos\\SoftwareEngg\\Lecs\\Implementations\\FileWatcher\\Executive\\TestFile.txt");

            IFileListener listener = new Listener();
            communicator.Subscribe(listener);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
