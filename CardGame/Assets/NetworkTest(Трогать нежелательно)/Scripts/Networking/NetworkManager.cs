using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    public ClientTCP clientTCP = new ClientTCP();
    [SerializeField]private GameObject playerPref;
    private Dictionary<int, GameObject> playerList = new Dictionary<int, GameObject>();
    public int MyIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        UnityThread.initUnityThread();
    }
    void Start () {
        clientTCP.Connect();

	}


}
