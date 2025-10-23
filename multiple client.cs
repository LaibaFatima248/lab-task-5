
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
class UDPArraySender
{
    static void Main()
    {
        int[] number = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        var client = new UdpClient();
        var serverEP = new
        IPEndPoint(IPAddress.Parse("10.10.20.10"), 9005);
        Console.WriteLine("Sending integer array via UDP...");
        for (int i = 0; i < number.Length; i++)
        {
            byte[] packet = new byte[8];//4 bytes seq+4 bytes value
            BitConverter.GetBytes(i).CopyTo(packet, 0);
            BitConverter.GetBytes(number[i]).CopyTo(packet, 4);
            client.Send(packet, packet.Length, serverEP);
            Console.WriteLine($"Sent index{i},value{number[i]}");
            Thread.Sleep(500);
        }
        client.Send(Encoding.UTF8.GetBytes("END"), 3, serverEP);
        Console.WriteLine("Array sent successfully!");
    }
}
