using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public class Server : Host
    {
        public bool StopRequest { get; set; }
        public CancellationToken Token { get; set; }
        public long ClientNumber { get; set; }
        public List<Task> ServerTasks { get; set; }

        public List<Task> ClientsPool { get; set; }
        public Signals CurrentServerSignal { get; set; }
        private Dictionary<long, TcpClient> _tcpClients { get; set; }

        private TcpListener _serverSocket { get; init; }

        public Server()
        {
            _tcpClients = new Dictionary<long, TcpClient>();
            StopRequest = false;
            Token = new CancellationToken(StopRequest);
            ClientNumber = 0;
            ServerTasks = new List<Task>();
            GetCurrentIpAddress();
            _serverSocket = new TcpListener(CurrentIpAddress, Host.DefaultPort);
            _serverSocket.Server.ReceiveBufferSize = DefaultReceiveBufferSize;
            _serverSocket.Server.SendBufferSize = DefaultReceiveBufferSize;
            _serverSocket.Server.ReceiveTimeout = DefaultReceiveTimeOut;
            _serverSocket.Server.SendTimeout = DefaultSendTimeOut;
        }

        ~Server()
        {
#pragma warning disable 4014
            DisconnectAsync();
#pragma warning restore 4014
        }

        public static IHost<Host> Instance { get; } = new Server();

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override async Task Start()
        {
            CurrentServerSignal = Signals.RUNNING;
            try
            {
                _serverSocket.Start();
                do
                {
                    var currentClient = await _serverSocket.AcceptTcpClientAsync();
                    NetworkStream clientNetworkStream = currentClient.GetStream();
                    Console.WriteLine($"Accepting client {currentClient.GetHashCode()}");
                    ServerTasks.Add(ListenAsync(currentClient,clientNetworkStream, Token));
                    ServerTasks.Add(BroadcastAsync(currentClient, Token));
                    await Task.WhenAny(ServerTasks);
                } while (!StopRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            throw new NotImplementedException();
        }

        public override async Task Reload()
        {
            throw new NotImplementedException();
        }

        public override async Task Stop()
        {
            StopRequest = true;
        }

        public override async Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        private async Task ListenAsync(TcpClient client, NetworkStream clientNetworkStream,CancellationToken token)
        {
            try
            {
                _tcpClients.Add(ClientNumber, client);
                ClientNumber++;
                ClientDatas clientDatas = new ClientDatas();
                Action currentClientListenAction = async () =>
                {
                    byte[] currentBuffer = new byte[DefaultReceiveBufferSize];
                    Console.WriteLine($"New listen task for client {client.GetHashCode()}");

                    do
                    {
                        try
                        {
                            

                            if (clientNetworkStream.CanRead)
                            {
                                StringBuilder currentStringBuilder = new StringBuilder();
                                do // Start converting bytes to string
                                {
                                    int bytesReaded = clientNetworkStream.Read(currentBuffer, 0, currentBuffer.Length);
                                    currentStringBuilder.AppendFormat("{0}",
                                        Encoding.ASCII.GetString(currentBuffer, 0, bytesReaded));
                                } while (clientNetworkStream.DataAvailable); // Until stream data is available

                                if (currentStringBuilder != null)
                                {
                                    // Stream data is ready and converted to string
                                    // Do some stuffs
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    } while (clientDatas.CurrentClientSignal != Signals.DISCONNECTED);
                };

                Task currentClientPool = Task.Run(currentClientListenAction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task BroadcastAsync(TcpClient client, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}