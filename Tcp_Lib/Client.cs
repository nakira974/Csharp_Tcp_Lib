using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public class Client : Host
    {
        private TcpClient _ClientSocket { get; init; }
        public IPAddress ServerAddress { get; set; }
        public Client()
        {
            _ClientSocket = new TcpClient(GetCurrentHostName(), DefaultPort);
            _ClientSocket.SendBufferSize = DefaultSendBufferSize;
            _ClientSocket.ReceiveBufferSize = DefaultReceiveBufferSize;
            _ClientSocket.ReceiveTimeout = DefaultReceiveTimeOut;
            _ClientSocket.SendTimeout = DefaultSendTimeOut;
        }

        ~Client()
        {
#pragma warning disable 4014
            DisconnectAsync();
#pragma warning restore 4014
        }

        public static IHost Instance { get; } = new Client();

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

        public override async Task ConnectAsync()
        {
            try
            {
                await _ClientSocket.ConnectAsync(ServerAddress, DefaultPort);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public override async Task DisconnectAsync()
        {
            try
            {
                _ClientSocket.Client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}