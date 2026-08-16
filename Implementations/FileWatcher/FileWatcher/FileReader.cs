using System.Diagnostics;

namespace FileWatcher
{
    public class FileReader : IFileConnector
    {

        FileSystemWatcher _fileSystemWatcher;
        IFileListener _listener;

        public FileReader(string filePath)
        {
            _fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(filePath), Path.GetFileName(filePath));
            _fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
            _fileSystemWatcher.Changed += Changed;
            _fileSystemWatcher.EnableRaisingEvents = true;
            Debug.WriteLine($"FileReader initialized and watching file: {filePath}");
        }

        private void Changed(object sender, FileSystemEventArgs e)
        {
            string content = "";
            try
            {
                content = File.ReadAllText(e.FullPath);
            }
            catch(IOException)
            {
                Thread.Sleep(100); 
            }
            
            if (content != null)
            {
                _listener?.OnFileChanged(content);
            }
            else
            {
                Debug.WriteLine("File content is null.");
            }
        }

        public void Subscribe(IFileListener listener)
        {
            _listener = listener;
            Debug.WriteLine("Listener subscribed to file changes.");
        }

    }
}
