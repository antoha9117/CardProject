using System;
using System.Threading;

namespace CardServer
{
    class Program
    {
        
        private static Thread threadConsole;
        static void Main(string[] args)
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();
            SetupServer();
            //Запуск сервера
        }

        static void SetupServer()
        {
            MySQL.MySQLInit();
         
            for (int i = 0; i < Constants.MAX_PLAYER; i++)
            {
                ServerTCP.Clients[i] = new Client();
                Types.TempPlayer[i] = new Types.TempPlayerRec();
             
            }
            ServerHandleData.InitMessages();
            ServerTCP.InitNetwork();
        }

        private static void ConsoleThread()
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "online")
                {
                    Log("Онлайн состовляет : "+ ServerTCP.onlineCount.ToString() + " игроков") ;
                }
            }
        }
        public static void Log(string log)
        {
            Console.WriteLine("["+DateTime.Now.ToString("HH:mm:ss") + "] " + log);
        }
    }
    
}
