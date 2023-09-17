using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the host address (e.g., www.example.com): ");
                string webAddress = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(webAddress))
                {
                    Console.WriteLine("Host address cannot be empty.");
                    continue;
                }

                IPAddress[] addresses = Dns.GetHostAddresses(webAddress);
                if (addresses.Length > 0)
                {
                    Console.WriteLine($"Host IP: {addresses[0]}");
                }
                else
                {
                    Console.WriteLine("Invalid host or host is unreachable.");
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                Console.WriteLine("Invalid host or host is unreachable.");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("FormatException for host.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
