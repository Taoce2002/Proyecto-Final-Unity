using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CrearRoom : MonoBehaviourPunCallbacks
{
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void crearRoom(){
        number = Random.Range(100,999);
        Debug.Log("Creando Sala");
        PhotonNetwork.JoinOrCreateRoom("Sala "+ number, new RoomOptions(){MaxPlayers = 4}, TypedLobby.Default);
        Debug.Log("Se creo la Sala");

        PhotonNetwork.LoadLevel("Nivel1");
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        Debug.Log("No se pudo crear la sala");
        crearRoom();
        Debug.Log("Se creara otra");
    }

}
