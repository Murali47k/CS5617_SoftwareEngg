using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    public class Filemanager
    {
        private string filePath = "data.txt";

        public Filemanager()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Read all data from file
        private Dictionary<string, string> ReadData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                int index = line.IndexOf('=');

                if (index == -1)
                    continue;

                string key = line.Substring(0, index);
                string value = line.Substring(index + 1);

                data[key] = value;
            }

            return data;
        }

        // Write dictionary back to file
        private void WriteData(Dictionary<string, string> data)
        {
            List<string> lines = new List<string>();

            foreach (var item in data)
            {
                lines.Add(item.Key + "=" + item.Value);
            }

            File.WriteAllLines(filePath, lines);
        }

        // Save or Update
        public void Save(string key, string value)
        {
            Dictionary<string, string> data = ReadData();

            data[key] = value;

            WriteData(data);

            Console.WriteLine("Saved Successfully.");
        }

        // Retrieve
        public void Retrieve(string key)
        {
            Dictionary<string, string> data = ReadData();

            if (data.ContainsKey(key))
            {
                Console.WriteLine("Value : " + data[key]);
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
        }

        // Delete
        public void Delete(string key)
        {
            Dictionary<string, string> data = ReadData();

            if (data.Remove(key))
            {
                WriteData(data);
                Console.WriteLine("Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
        }

        // Display all entries
        public void DisplayAll()
        {
            Dictionary<string, string> data = ReadData();

            if (data.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            Console.WriteLine("\nStored Records:");
            foreach (var item in data)
            {
                Console.WriteLine(item.Key + " = " + item.Value);
            }
        }
    }
}