using System;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public interface IHost : IDisposable
    {
        public Task Reload();
        public Task Stop();
        public Task<IAsyncResult> SendByteAsync();
        public Task<IAsyncResult> ReceiveByteAsync();
        public Task ConnectAsync();
        public Task DisconnectAsync();


    }
}