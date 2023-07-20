using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class UnirseRoom : MonoBehaviourPunCallbacks
{
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void unirseRooms(){
    
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Se unio a una sala");
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("No se pudo conectar la sala, se creara una");
        crearRoom();
    }

    public void crearRoom(){
        number = Random.Range(100,999);
        Debug.Log("Creando Sala");
        PhotonNetwork.JoinOrCreateRoom("Sala "+ number, new RoomOptions(){MaxPlayers = 4}, TypedLobby.Default);
        Debug.Log("Se creo la Sala");
        PhotonNetwork.LoadLevel("Nivel1");
    }
}
