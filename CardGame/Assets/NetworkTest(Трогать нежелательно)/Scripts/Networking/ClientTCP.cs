using System;
using System.Net.Sockets;
using UnityEngine;

public class ClientTCP {
    public TcpClient playerSocket;
    private bool connecting;
    private bool connected;
    public  NetworkStream myStream;
    private byte[] asyncBuff;

    public void Connect()
    {
        playerSocket = new TcpClient();
        playerSocket.ReceiveBufferSize = 4096;
        playerSocket.SendBufferSize = 4096;
        playerSocket.NoDelay = false;
        asyncBuff = new byte[8192];
        playerSocket.BeginConnect("127.0.0.1",5555, new AsyncCallback(ConnectCallback),playerSocket);
        connecting = true;

    }

    private void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            playerSocket.EndConnect(ar);
            if(playerSocket.Connected == false)
            {
                connected = false;
                connecting = false;
                return;
            }
            else
            {
                playerSocket.NoDelay = true;
                myStream = playerSocket.GetStream();
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
                connected = true;
                connecting = false;
                Debug.Log("Подключение к серверу прошло успешно!");
             //   ClientSendData.Test();
            }
        }
        catch
        {
            connected = false;
            connecting = false;
            Debug.Log("Невозможно подключиться к серверу.");

        }
    }

    private void OnReceive(IAsyncResult ar)
    {
        try
        {
            int byteAmt = myStream.EndRead(ar);
            byte[] myBytes = new byte[byteAmt];
            Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteAmt);
            if (byteAmt == 0) return;

            UnityThread.executeInUpdate(() =>
            {
                ClientHandleData.HandleData(myBytes);
            });
            myStream.BeginRead(asyncBuff, 0, playerSocket.SendBufferSize, OnReceive, null);
        }
        catch 
        {

            
        }
    }

}
