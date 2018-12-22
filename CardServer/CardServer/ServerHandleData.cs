using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardServer
{
    public class ServerHandleData
    {
        private delegate void Packet_(long index, byte[] data);
        private static Dictionary<long, Packet_> packets = new Dictionary<long, Packet_>();
      //private static long pLength;
        
        
        public static  void InitMessages()
        {
            Program.Log("Инициализация сервера...");
            packets.Add((long)ClientPackets.CRegisterAccount, Packet_CRegisterAccount);
            packets.Add((long)ClientPackets.CLoginAccount, Packet_CLoginAccount);

        }

       #region обработка полученных от клиента пакетов

      /*  public static void HandleData(long index, byte[] data)
        {
      //      Console.WriteLine(index.ToString() + " helllo man");
            byte[] Buffer;
            Buffer = (byte[])data.Clone();

            if (Types.TempPlayer[index].Buffer == null) Types.TempPlayer[index].Buffer = new ByteBuffer();
            Types.TempPlayer[index].Buffer.WriteBytes(Buffer);

            if (Types.TempPlayer[index].Buffer.Count() == 0)
            {
                Types.TempPlayer[index].Buffer.Clear();
                return;
            }

            if (Types.TempPlayer[index].Buffer.Length() >= 4)
            {
                pLength = Types.TempPlayer[index].Buffer.ReadLong(false);
                if (pLength <= 0)
                {
                    Types.TempPlayer[index].Buffer.Clear();
                    return;
                }
            }
            while (pLength > 0 || pLength <= Types.TempPlayer[index].Buffer.Length() - 8)
            {
                if (pLength <= Types.TempPlayer[index].Buffer.Length() - 8)
                {
                    Types.TempPlayer[index].Buffer.ReadLong();
                    data = Types.TempPlayer[index].Buffer.ReadBytes((int)pLength);
                    HandleDataPackets(index, data);
                }
                pLength = 0;
                if (Types.TempPlayer[index].Buffer.Length() >= 4)
                {
                    pLength = Types.TempPlayer[index].Buffer.ReadLong(false);
                    if (pLength < 0)
                    {
                        Types.TempPlayer[index].Buffer.Clear();
                        return;
                    }
                }
            }
            if(pLength  <= 1)
            {
                Types.TempPlayer[index].Buffer.Clear();
            }
        }*/
        public static void HandleData(long index, byte[] data)
        {
            int packetnum;
            Packet_ Packet;
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            packetnum = buffer.ReadInteger();
            buffer = null;

            if (packetnum == 0)
                return;

            if (packets.TryGetValue(packetnum, out Packet))
            {
                Packet.Invoke(index, data);
            }

        }
        public static void HandleDataPackets(long index, byte[] data)
        {
            long packetnum;
            ByteBuffer buffer;
            Packet_ packet;

            buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            packetnum = buffer.ReadLong();
            buffer = null;

            if (packetnum == 0) return;

            if(packets.TryGetValue(packetnum, out packet))
            {
                packet.Invoke(index, data);
            }
        }

        #endregion

        private static void Packet_CRegisterAccount(long index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            long packetNum = buffer.ReadLong();
            string username = buffer.ReadString();
            string password = buffer.ReadString();
            string email = buffer.ReadString();
            Database.AddAccount(username,password,email);
            Program.Log($"Регистрация пользователя:\n               Логин: {username}\n               Хеш пароля: {password}\n               Email: {email}");
        }

        private static void Packet_CLoginAccount(long index, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            long packetNum = buffer.ReadLong();
            string username = buffer.ReadString();
            string password = buffer.ReadString();

            if (!Database.AccountExist(index,username))
            {
                return;
            }
            if (!Database.PasswordOK(index,username, password))
            {
                return;
            }
            Program.Log($"Пользователь {username} успешно авторизовался!");
            ServerTCP.SendAlertTo(index, "You logged in!");
        }
    }

}
