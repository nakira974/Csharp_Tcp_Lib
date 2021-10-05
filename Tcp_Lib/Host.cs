using System;
using System.Net;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public abstract class Host : IHost
    {
        protected const int DefaultSendTimeOut = 3600;
        protected const int DefaultReceiveTimeOut = 10000;
        protected const int DefaultSendBufferSize = 1024;
        protected const int DefaultReceiveBufferSize = 4096;
        protected const int DefaultPort = 9001;
        protected IPAddress CurrentIpAddress { get; set; }

        protected string GetCurrentHostName()
        {
            return Dns.GetHostName();
        }
        protected void GetCurrentIpAddress()
        {
            string hostName = Dns.GetHostName();
#pragma warning disable 618
            CurrentIpAddress = Dns.GetHostByName(hostName).AddressList[0];
#pragma warning restore 618
        }
        public abstract void Dispose();
        public abstract Task Start();
        public abstract Task Reload();
        public abstract Task Stop();
        public async Task<IAsyncResult> SendByteAsync(string jsonContent)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReceiveByteAsync()
        {
            throw new NotImplementedException();
        }
        public abstract Task ConnectAsync();
        public abstract Task DisconnectAsync();
    }
}