using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public class Server : Host
    {
        private TcpListener _ServerSocket { get; init; }
        public Server()
        {
            GetCurrentIpAddress();
            _ServerSocket = new TcpListener(CurrentIpAddress, Host.DefaultPort);
            _ServerSocket.Server.ReceiveBufferSize = DefaultReceiveBufferSize;
            _ServerSocket.Server.SendBufferSize = DefaultReceiveBufferSize;
            _ServerSocket.Server.ReceiveTimeout = DefaultReceiveTimeOut; 
            _ServerSocket.Server.SendTimeout = DefaultSendTimeOut;
            
        }

         ~Server()
        {
#pragma warning disable 4014
            DisconnectAsync();
#pragma warning restore 4014
        }

        public static Server Instance { get; } = new Server();

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override async Task Reload()
        {
            throw new NotImplementedException();
        }

        public override async Task Stop()
        {
            
        }
        
        public override async Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task ListenAsync()
        {
            throw new NotImplementedException();
        }
    }
}