using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;

namespace Lab10;

class ChatClient
{
    private readonly StreamReader _reader;
    private readonly StreamWriter _writer;

    public ChatClient(TcpClient client)
    {
        _reader = new StreamReader(client.GetStream());
        _writer = new StreamWriter(client.GetStream());
        {
            AutoFlush = true;
        }
    }

    public void Send(string message)
    {
        _writer.WriteLine(message);
    }

    public string? Read()
    {
        if (!_reader.EndOfStream)
        {
            return _reader.ReadLine();
        }
        else
        {
            return null;
        }
    }

    public void Dispose()
    {
        _reader.Dispose();
        _writer.Dispose();
    }
    
    public int Id { get; set; }
}

public class ChatDemo
{
    // private record Clients(int Id, bool IsConnected); // this looks to be wrong, but prof was writing so fast practically no one could keep up
    public static void Run()
    {
        TcpListener server = new(IPAddress.Loopback, 2137);
        server.Start();
        Console.WriteLine("Server started");
        Task.Run(() =>
        {
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                Console.WriteLine("Press Q to exit...");
            }
            server.Stop();
        });
        while (true)
        {
            Console.WriteLine("Waiting for connection...");
            try
            {
                TcpClient clientSocket = server.AcceptTcpClient();
                var client = new ChatClient(clientSocket)
                {
                    Id = Clients.Count + 1,
                };
                if (!Clients.TryAdd(client.Id, client))
                {
                    break;
                }

                Task.Run(() =>
                {
                    Console.WriteLine("Client connected.");
                    while (client.IsConnected())
                    {
                        var message = client.Read();
                        foreach (var c in Clients)
                        {
                            c.Value.Send($"Message from {client.Id}: {message}");
                        }
                    }

                    Console.WriteLine("Client disconnected.");
                    Clients.Remove(client.Id, out var removed);
                    removed?.Dispose();
                });
            }
            catch (SocketException e)
            {
                Console.WriteLine($"Exception: {e}");
                break;
            }
        }
    }
}