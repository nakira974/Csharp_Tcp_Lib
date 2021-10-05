using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public class Server : Host
    {
        private TcpListener _ServerSocket { get; init; }
        private Server()
        {
            GetCurrentIpAddress();
            _ServerSocket = new TcpListener(CurrentIpAddress, Host.DefaultPort);
            _ServerSocket.Server.ReceiveBufferSize = DefaultReceiveBufferSize;
            _ServerSocket.Server.SendBufferSize = DefaultReceiveBufferSize;
            _ServerSocket.Server.ReceiveTimeout = DefaultReceiveTimeOut; 
            _ServerSocket.Server.SendTimeout = DefaultSendTimeOut;
            
        }

        public static Server Instance { get; } = new Server();

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> Reload()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> Stop()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> SendByteAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> ReceiveByteAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAsyncResult> DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task ListenAsync()
        {
            throw new NotImplementedException();
        }
    }
}