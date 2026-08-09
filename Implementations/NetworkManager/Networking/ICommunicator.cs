namespace Networking
{
    public interface ICommunicator
    {
        void SendData(string addr,string data);

        int GetCount();
    }
}
