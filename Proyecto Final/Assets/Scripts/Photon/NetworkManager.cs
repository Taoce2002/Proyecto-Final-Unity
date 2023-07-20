using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connect Master");

    }

    // Update is called once per frame
    public override void OnConnectedToMaster(){

        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Connected");
    }

    public override void OnDisconnected (DisconnectCause cause){
        Debug.Log("Desconectado, problemas");
    }
}
