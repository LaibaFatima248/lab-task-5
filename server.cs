using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        var listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Server running...");
        while (true)
        {
            var client = listener.AcceptTcpClient();
            var ns = client.GetStream();
            byte[] data = new byte[1024];
            int bytes = ns.Read(data, 0, data.Length);
            int n = int.Parse(Encoding.UTF8.GetString(data, 0, bytes));
            string result = "";
            for (int i = 1; i <= 10; i++)
                result += $"{n} x {i} = {n * i}\n";
            ns.Write(Encoding.UTF8.GetBytes(result));
            ns.Close();
            client.Close();
            Console.WriteLine($"Table for {n} sent to client.");
        }
    }
}