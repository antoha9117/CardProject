using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ClientSendData : MonoBehaviour
{
    public static ClientSendData instance;
    public static ClientTCP clientTCP;


    [Header("Registration")]
    public Text _username;
    public Text _password;
    public Text _email;

    [Header("Authorization")]
    public Text username;
    public Text password;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        clientTCP = GetComponent<NetworkManager>().clientTCP;
    }

    public void SendAuth()
    {

        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteLong((long)ClientPackets.CLoginAccount);
        buffer.WriteString(username.text);
        buffer.WriteString(password.text);

        SendDataToServer(buffer.ToArray());
        buffer = null;
    }
    public void SendNewAccount()
    {
 
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteLong((long)ClientPackets.CRegisterAccount);
        buffer.WriteString(_username.text);
        buffer.WriteString(_password.text);
        buffer.WriteString(_email.text);



        SendDataToServer(buffer.ToArray());
        buffer = null;
    }
    public static void SendDataToServer(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        clientTCP.myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
        buffer = null;
    }


}
