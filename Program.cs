using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketTcpClient
{
    class Program
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 5020; // порт сервера
        static IPAddress iPAddress = IPAddress.Parse("192.168.1.30");
        static void Main(string[] args)
        {

            try
            {
                while (true)
                {
                    IPEndPoint ipPoint = new IPEndPoint(iPAddress, port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                
                    socket.Connect(ipPoint);
                    /*
                     * Для выключения сканера количество данных - 3 - Значения 2 1 6
                     * Для включения - 4 - Значаения - 2 1 19 1
                     */
                    Console.Write("Введите количество данных в сообщении:");
                    int number = int.Parse(Console.ReadLine());
                    byte[] data = new byte[number];
                    for(int i = 0; i < number; i++)
                    {
                        Console.WriteLine($"Введите значение №{i}");
                        data[i] = byte.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                    for(int i = 0; i < number; i++)
                    {
                        Console.Write(data[i]);
                    }
                    socket.Send(data);

                    

                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //private const int port = 56000;
        //private const string server = "192.168.1.30";

        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        TcpClient client = new TcpClient();
        //        client.Connect(server, port);

        //        byte[] data = new byte[32];
        //        data[1] = 5;
        //        data[2] = 7;
        //        StringBuilder response = new StringBuilder();
        //        NetworkStream stream = client.GetStream();
        //        stream.Write(data, 0, data.Length);
        //        do
        //        {
        //            int bytes = stream.Read(data, 0, data.Length);
        //            response.Append(Encoding.UTF8.GetString(data, 0, bytes));
        //        }
        //        while (stream.DataAvailable); // пока данные есть в потоке

        //        Console.WriteLine(response.ToString());

        //        // Закрываем потоки
        //        stream.Close();
        //        client.Close();
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("SocketException: {0}", e);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: {0}", e.Message);
        //    }

        //    Console.WriteLine("Запрос завершен...");
        //    Console.Read();
        //}
    }
}