using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientHandleData : MonoBehaviour
{
    public static ByteBuffer playerBuffer;
    private delegate void Packet_(byte[] data);
    private static Dictionary<long, Packet_> packets = new Dictionary<long, Packet_>();
    public static NetworkManager networkManager;
    private static long pLength;


    private void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
        InitMessages();
    }

    private static void InitMessages()
    {
        Debug.Log("Инициализация соединения...");
        packets.Add((long)ServerPackets.SAlertMsg, Packet_SAlertMsg);

    }
#region Обработка полученных пакетов
    public static void  HandleData(byte[] data)
    {
        byte[] Buffer;
        Buffer = (byte[])data.Clone();

        if (playerBuffer == null) playerBuffer = new ByteBuffer();
        playerBuffer.WriteBytes(Buffer);

        if (playerBuffer.Count() == 0)
        {
            playerBuffer.Clear();
            return;
        }

        if (playerBuffer.Length() >= 8)
        {
            pLength = playerBuffer.ReadLong(false);
            if (pLength <= 0)
            {
                playerBuffer.Clear();
                return;
            }
        }
        if (playerBuffer.Length() >= 8)
        {
            pLength = playerBuffer.ReadLong(false);
            if (pLength <= 0)
            {
                playerBuffer.Clear();
                return;
            }
        }
        while (pLength > 0 || pLength <= playerBuffer.Length() - 8)
        {
            if (pLength <= playerBuffer.Length() - 8)
            {
                playerBuffer.ReadLong();
                data = playerBuffer.ReadBytes((int)pLength);
                HandleDataPackets(data);
            }
            pLength = 0;
            if (playerBuffer.Length() >= 8)
            {
                pLength = playerBuffer.ReadLong(false);
                if (pLength < 0)
                {
                    playerBuffer.Clear();
                    return;
                }
            }
        }

    }
    public static void HandleDataPackets(byte[] data)
    {
        long packetnum;
        ByteBuffer buffer;
        Packet_ packet;

        buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadLong();
        buffer = null;

        if (packetnum == 0) return;

        if (packets.TryGetValue(packetnum, out packet))
        {
            packet.Invoke(data);
        }
    }
#endregion

    private static void Packet_SAlertMsg(byte[] data)
    {
   
        long packetnum; ByteBuffer buffer;
        buffer = new ByteBuffer();

        buffer.WriteBytes(data);
        packetnum = buffer.ReadLong();

        string alertMessage = buffer.ReadString();

        Debug.Log(alertMessage);
    }

}
