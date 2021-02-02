using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
   
    public override void OnStartLocalPlayer() // Al conectarse
    {
       
        GameObject lobbyCamera = GameObject.FindGameObjectWithTag("LobbyCamera"); // BUscamos la camara del Lobby
        lobbyCamera.SetActive(false);// La desconectamos

    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.CmdAddPlayerToList(this.gameObject);
    }

  
}
