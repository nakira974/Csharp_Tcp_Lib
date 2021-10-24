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

        public List<ServerTask> ClientsPool { get; set; }
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
            ClientsPool = new List<ServerTask>();
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
                    var currentListenTask = ListenAsync(currentClient, clientNetworkStream, Token);
                    var currentBroadcastTask = BroadcastAsync(currentClient, Token);
                    ServerTasks.Add(currentListenTask);
                    ServerTasks.Add(currentBroadcastTask);
                    ClientsPool.Add(new ServerTask()
                    {
                        Task = currentListenTask,
                        TaskType = TaskType.LISTEN,
                        ClientId = currentClient.GetHashCode()
                    });
                    ClientsPool.Add(new ServerTask()
                    {
                        Task = currentBroadcastTask,
                        TaskType = TaskType.MONOCAST,
                        ClientId = currentClient.GetHashCode()
                    });
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
                GameDatas gameDatas = new GameDatas();
                Action currentClientListenAction = async () =>
                {
                    byte[] currentBuffer = new byte[DefaultReceiveBufferSize];
                    Console.WriteLine($"New listen task for client {client.GetHashCode()}");

                    do
                    {
                        try
                        {
                            

                            StringBuilder username = new StringBuilder();
                            StringBuilder currentStringBuilder = new StringBuilder();

                            if (clientNetworkStream.CanRead)
                            {
                                int bytesReaded = await clientNetworkStream.ReadAsync(currentBuffer, 0, currentBuffer.Length);
                                username.AppendFormat("{0}",
                                    Encoding.ASCII.GetString(currentBuffer, 0, bytesReaded));
                                Console.WriteLine($"Current username :{username.ToString()}");
                                
                                do // Start converting bytes to string
                                { 
                                    bytesReaded = await clientNetworkStream.ReadAsync(currentBuffer, 0, currentBuffer.Length);
                                    currentStringBuilder.AppendFormat("{0}",
                                        Encoding.Latin1.GetString(currentBuffer, 0, bytesReaded));
                                    if (currentStringBuilder != null)
                                    {
                                        //TO DO
                                        Console.WriteLine($"{username.ToString()} said:{currentStringBuilder.ToString()}");
                                    }
                                } while (clientNetworkStream.DataAvailable); // Until stream data is available

                                
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    } while (gameDatas.CurrentPlayerSignal != Signals.DISCONNECTED);
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