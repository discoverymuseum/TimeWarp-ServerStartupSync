using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerStartupSync
{
    class Program
    {
        public static string configFile;
        public static string targetIPstring;
        public static string localIPstring;
        public static string command;
        public static int port;
        public static bool canConnect;

        static void Main(string[] args)
        {
            canConnect = false;

            string configFile = "config.ini";

            foreach (string line in args)
            {
                if (line.Contains("config"))
                {
                    configFile = line.Split("=")[1];
                    Console.WriteLine("Configuration file: " + configFile);
                }
            }

            string[] config = File.ReadAllLines(configFile);

            foreach (string line in config)
            {
                if (line.Contains("localip"))
                {
                    localIPstring = line.Split("=")[1];
                }

                if (line.Contains("targetip"))
                {
                    targetIPstring = line.Split("=")[1];
                }


                if (line.Contains("command"))
                {
                    command = line.Split("=")[1];
                }

                if (line.Contains("port"))
                {
                    port = int.Parse(line.Split("=")[1]);
                }
            }

            Console.WriteLine("Local server IP: " + localIPstring);
            Console.WriteLine("Target server IP: " + targetIPstring);
            Console.WriteLine("Communication TCP port: " + port);
            Console.WriteLine("Executable command: " + command);


            Thread TCPServerListenerThread = new Thread(TCPServerListener);
            TCPServerListenerThread.Start();

            Thread TCPConnectorThread = new Thread(TCPConnector);
            TCPConnectorThread.Start();

        }


        // This method keeps listening for incoming connections
        // if an connection has been established, execute the command

        public static void TCPServerListener()
        {
            IPAddress thisIP = IPAddress.Parse(localIPstring);

            TcpListener tcpListener = new TcpListener(thisIP, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Console.WriteLine("Connected!");
                break;
            }
        }


        // This method keeps trying to connect to the target
        // server IP. If the connection is succesfull, execute the command

        public static void TCPConnector()
        {
            IPAddress targetIP = IPAddress.Parse(targetIPstring);
            TcpClient tcpClient = new TcpClient();
            tcpClient.ReceiveTimeout = 2000;
            tcpClient.SendTimeout = 2000;

            while (true)
            {
                try
                {
                    tcpClient.Connect(targetIPstring, port);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Kan (nog) niet verbinden met de dependency cluster...");
                    Thread.Sleep(2000);
                }

                if (tcpClient.Connected)
                {
                    break;
                }
            }

            Console.WriteLine("Cluster gevonden!");
            System.Diagnostics.Process.Start(command);
            tcpClient.Close();
            Thread.CurrentThread.Interrupt();

        }


    }
}
