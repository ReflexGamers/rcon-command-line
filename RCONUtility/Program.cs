using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryMaster;
using System.Net;
using System.Net.Sockets;

namespace RCONUtility
{
    class Program
    {
        static String ip = "";
        static ushort port = 27015;
        static String password = "";
        static String command = "";

        // example: rcon.exe -ip 10.10.1.112 -port 27015 -password abc -cmd "sm plugins reload potato"
        static void Main(string[] args)
        {
            ParseArgs(args);
            if (CheckArgs())
            {
                CallServer();
            }
        }

        static IPAddress GetIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        static void CallServer()
        {
            Server server = ServerQuery.GetServerInstance(EngineType.Source, ip, port);

            try
            {
                Rcon rcon = server.GetControl(password);
                Console.WriteLine("Server connection established.");
                Console.WriteLine("Sending command: {0}", command);
                String response = rcon.SendCommand(command);
                Console.WriteLine(response);
            }
            catch (System.Net.Sockets.SocketException se)
            {
                Console.WriteLine(se.Message);
            }

            server.Dispose();
        }

        static void ParseArgs(string[] args)
        {
            int argCount = args.Length;

            for (int i = 0; i < argCount; i++)
            {
                switch (args[i])
                {
                    case "-ip":
                        ip = args[++i];
                        if (ip == "localhost")
                        {
                            ip = GetIP().ToString();
                        }
                        break;
                    case "-port":
                        if (!UInt16.TryParse(args[++i], out port)) {
                            Console.WriteLine("ERROR: Invalid port");
                        }
                        break;
                    case "-password":
                        password = args[++i];
                        break;
                    case "-cmd":
                        command = args[++i];
                        break;
                }
            }
        }

        static bool CheckArgs()
        {
            if (ip == "")
            {
                Console.WriteLine("ERROR: IP not provided");
                return false;
            }

            if (password == "")
            {
                Console.WriteLine("ERROR: Password not provided");
                return false;
            }

            if (command == "")
            {
                Console.WriteLine("ERROR: Command not provided");
                return false;
            }

            return true;
        }
    }
}
