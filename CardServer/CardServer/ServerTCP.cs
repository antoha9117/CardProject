using System;
using System.Net;
using System.Net.Sockets;

namespace CardServer
{
    class ServerTCP
    {
        public static TcpListener serverSocket;

        public static Client[] Clients = new Client[Constants.MAX_PLAYER];

        public static int onlineCount = 0;

        private static byte[] asyncBuff;

        public static void InitNetwork()
        {
            asyncBuff = new byte[8192];

            serverSocket = new TcpListener(IPAddress.Any, 5555);
            serverSocket.Start();
            serverSocket.BeginAcceptTcpClient(OnClientConnect,null);

            Program.Log("Сервер запущен!");
        }
        private static void OnClientConnect(IAsyncResult ar)
        {
     
            TcpClient client = serverSocket.EndAcceptTcpClient(ar);
            client.NoDelay = false;
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
            
            for (int i = 0; i < Constants.MAX_PLAYER; i++)
            {
              
                if (Clients[i].socket == null)
                {
                    
                    Clients[i].socket = client;
                    Clients[i].index  = i;
                    Clients[i].ip  = client.Client.RemoteEndPoint.ToString();
                    Clients[i].Start();
                    Program.Log("Было установлено подключение c " + Clients[i].ip);
                    onlineCount++;
                    //SendWelcomeMessage(i);
                    
                    return;
                }

            }

        }
        public static void SendDataTo(long index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteLong((data.GetUpperBound(0) - data.GetLowerBound(0)) + 1);
            buffer.WriteBytes(data);
            
            Clients[index].myStream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length, null, null);
            buffer = null;
        }

        public static void SendAlertTo(long index, string msg)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteLong((long)ServerPackets.SAlertMsg);
            buffer.WriteString(msg);
            SendDataTo(index, buffer.ToArray());
          
        }

        


    }
     
}
