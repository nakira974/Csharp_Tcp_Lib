using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tcp_Lib;

namespace ConsoleApp1
{
    class Program
    {
       

       
        static async Task Main(string[] args)
        {
            if (args.Where(x => x.Contains("server")).ToList().Any())
            {
                Server server = new Server();
                await server.Start();
            }
            else
            {
                var client = new Client();
                await client.ConnectAsync("192.168.1.1");
            }
           
         
           
        }
    }
}