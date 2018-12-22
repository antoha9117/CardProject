using System;
using System.Net.Sockets;

namespace CardServer
{
    class Client
    {
        public int index;
        public string ip;
        public TcpClient socket;
        public NetworkStream myStream;
        private byte[] readBuff;

        public void Start()
        {
            socket.SendBufferSize = 4096;
            socket.ReceiveBufferSize = 4096;
            myStream = socket.GetStream();
            readBuff = new byte[4096];
            myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);

        }
        private void OnReceiveData(IAsyncResult ar)
        {
           // Console.WriteLine("abc");
            try
            {
                int readbytes = myStream.EndRead(ar);
                if(readbytes  <= 0)
                {
                    //Console.WriteLine("NOO");
                    CloseSocket("1");
                    return;
                }
                byte[] newBytes = new byte[readbytes];
                Buffer.BlockCopy(readBuff,0, newBytes, 0 ,readbytes );
                ServerHandleData.HandleData(index, newBytes);
                myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);

            }
            catch
            {
                CloseSocket("2");
                return;
            }
        }
        private void CloseSocket()
        {
            Program.Log("Подключение " + ip + " было закрыто.");
            ServerTCP.onlineCount--;
            socket.Close();
            socket = null;
        }
        private void CloseSocket(string s)
        {
            Program.Log("Подключение " + ip + " было закрыто. "+s);
            ServerTCP.onlineCount--;
            socket.Close();
            socket = null;
        }
    }
}
