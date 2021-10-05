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
            CurrentIpAddress = Dns.GetHostByName(hostName).AddressList[0];
        }
        public abstract void Dispose();
        public abstract Task Reload();
        public abstract Task Stop();
        public abstract Task<IAsyncResult> SendByteAsync();
        public abstract Task<IAsyncResult> ReceiveByteAsync();
        public abstract Task ConnectAsync();
        public abstract Task DisconnectAsync();
    }
}