using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher
{
    public interface IFileConnector
    {
        void Subscribe(IFileListener listener);
    }
}
