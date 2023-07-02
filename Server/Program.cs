
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Net.Sockets;
using System.Net;


namespace FitnessHelper
{
    public class Program
    {
        static async Task Main(string[] args)
        {




            const string ip = "192.168.0.102";
            const int port = 8080;


            
            Console.WriteLine("Запуск сервера....");
            using (TcpServer server = new TcpServer(ip, port))
            {
                Task servertask = server.ListenAsync();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "stop")
                    {
                        Console.WriteLine("Остановка сервера...");
                        server.Stop();
                        break;
                    }
                }
                await servertask;
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey(true);
            Environment.Exit(0);










        }
    }

}
