using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JuegoPhoton : MonoBehaviourPunCallbacks
{
    Player[] jugadores;
    public int jugador;
    public GameObject jugadorGO;
    public PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;
        Debug.Log("Se unio el jugador "+ jugador);

        PhotonNetwork.NickName = jugador.ToString();


    }

    public override void OnJoinedRoom(){
        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;

        Debug.Log("Ingreso el jugador "+ jugador);

        PhotonNetwork.NickName = jugador.ToString();
        Vector3 Spawn = new Vector3(20.14f, 1f, -26.25f);


        jugadorGO = PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity,0);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer){
        Debug.Log("Un jugador abandono");
        PhotonNetwork.LoadLevel("PantallaRoom");
        PhotonNetwork.LeaveRoom();
    }

}
