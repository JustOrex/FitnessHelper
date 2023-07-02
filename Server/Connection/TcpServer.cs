using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FitnessHelper
{
    
        internal class TcpServer : IDisposable
        {

            private readonly TcpListener _listener;
            private readonly List<Connection> _clients;
            bool disposed;

            public TcpServer(string ip ,int port)
            {
                _listener = new TcpListener(IPAddress.Parse(ip), port);
                _clients = new List<Connection>();
            }

            public async Task ListenAsync()
            {
                try
                {
                    _listener.Start();
                    while (true)
                    {
                        TcpClient client = await _listener.AcceptTcpClientAsync();
                        Console.WriteLine("Подключение: " + client.Client.RemoteEndPoint + " > " + client.Client.LocalEndPoint);
                        lock (_clients)
                        {
                            _clients.Add(new Connection(client, c => { lock (_clients) { _clients.Remove(c); } c.Dispose(); }));
                        }
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("Сервер остановлен.");
                }
            }

            public void Stop()
            {
                _listener.Stop();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (disposed)
                    throw new ObjectDisposedException(typeof(TcpServer).FullName);
                disposed = true;
                _listener.Stop();
                if (disposing)
                {
                    lock (_clients)
                    {
                        if (_clients.Count > 0)
                        {
                            Console.WriteLine("Отключаю клиентов...");
                            foreach (Connection client in _clients)
                            {
                                client.Dispose();
                            }
                            Console.WriteLine("Клиенты отключены.");
                        }
                    }
                }
            }

            ~TcpServer() => Dispose(false);

        }
    
}
