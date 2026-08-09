namespace Executive
{
    using FileManager;

    internal class Program
    {
        static void Main(string[] args)
        {
            Filemanager fm = new Filemanager();

            Console.WriteLine("Simple File Manager");
            Console.WriteLine("-------------------");
            Console.WriteLine("Commands:");
            Console.WriteLine("sav <key> <value>");
            Console.WriteLine("ret <key>");
            Console.WriteLine("del <key>");
            Console.WriteLine("dis");
            Console.WriteLine("q");

            while (true)
            {
                Console.Write("\n> ");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0].ToLower();

                switch (command)
                {
                    case "sav":
                        if (parts.Length < 3)
                        {
                            Console.WriteLine("Usage: sav <key> <value>");
                            break;
                        }

                        fm.Save(parts[1], parts[2]);
                        break;

                    case "ret":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Usage: ret <key>");
                            break;
                        }

                        fm.Retrieve(parts[1]);
                        break;

                    case "del":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Usage: del <key>");
                            break;
                        }

                        fm.Delete(parts[1]);
                        break;

                    case "dis":
                        fm.DisplayAll();
                        break;

                    case "q":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}