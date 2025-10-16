using System;
using System.Net.Sockets;
using System.Text;
class Client
{
    static void Main()
    {
        var client = new TcpClient("10.10.20.10", 5000);
        var ns = client.GetStream();
        Console.Write("Enter number:");
        string num = Console.ReadLine();
        ns.Write(Encoding.UTF8.GetBytes(num));
        byte[] data = new byte[4096];
        int bytes = ns.Read(data, 0, data.Length);
        Console.WriteLine("\n"+Encoding.UTF8.GetString(data,0,bytes));
        ns.Close();
        client.Close();
    }
}
