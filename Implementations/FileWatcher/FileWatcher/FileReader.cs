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
        }

        private void Changed(object sender, FileSystemEventArgs e)
        {
            _listener?.OnFileChanged(File.ReadAllText(e.FullPath));
        }

        public void Subscribe(IFileListener listener)
        {
            _listener = listener;
        }

    }
}
