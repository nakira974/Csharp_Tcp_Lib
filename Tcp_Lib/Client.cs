using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Lib
{
    public class Client : Host
    {
        private Host _hostImplementation;
        private TcpClient _ClientSocket { get; init; }
        public IPAddress ServerAddress { get; set; }
        public Client()
        {
            GetCurrentIpAddress();
            _ClientSocket = new TcpClient();
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

        public static IHost<Host> Instance { get; } = new Client();

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override async Task Start()
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
        

        public  async Task ConnectAsync(string ipAddress)
        {
            try
            {
                string author = "Maxime2";
                byte[] bytes = Encoding.ASCII.GetBytes(author);
                await _ClientSocket.ConnectAsync(ipAddress, DefaultPort);
                NetworkStream stream = _ClientSocket.GetStream();
                stream.Write(bytes, 0, bytes.Length);
                while (true)
                {
                    StringBuilder sb = new StringBuilder();
                    ConsoleKeyInfo Input;
                    Console.Write("Input Your Hidden String: ");
                    do
                    {
                        Input = Console.ReadKey(true);
                        sb.Append(Input.KeyChar);                            //<--- here
                    } while (Input.Key != ConsoleKey.Enter);
                    bytes = Encoding.Latin1.GetBytes(sb.ToString());
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        public override  async Task ConnectAsync()
        {
            try
            {  
                string author = "Maxime";
                byte[] bytes = Encoding.ASCII.GetBytes(author);
                await _ClientSocket.ConnectAsync(CurrentIpAddress.ToString(), DefaultPort);
                NetworkStream stream = _ClientSocket.GetStream();
                stream.Write(bytes, 0, bytes.Length);
                


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