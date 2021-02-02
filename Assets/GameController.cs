using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    public GameObject slenderManPrefab;
    public Transform slenderSpawnPoint;
    public List<GameObject> playersList;
    public GameObject slenderMan;
    public Transform newTarget;
    public int playerSelected;

    [SyncVar]
    public int playerConnected;

    public void Start()
    {
        Debug.Log("StartObjet"); 
        

    Debug.Log("Initializing  Server");

        if (isServer)
        {
            Debug.Log("Is the SERVER ");
            slenderMan = Instantiate(slenderManPrefab, slenderSpawnPoint.position, slenderSpawnPoint.rotation);
            NetworkServer.Spawn(slenderMan);

        }
    
    }

    [Command]
    public void CmdAddPlayerToList(GameObject newPlayer)
    {
       
        playersList.Add(newPlayer);
        Debug.Log("New Player Joined. Total players:" + playersList.Count);

    }

    private void Update()
    {
        if (isServer && Input.GetKeyDown(KeyCode.P))
        {

            int numberOfPlayers = playersList.Count;
            playerSelected = Random.Range(0, numberOfPlayers);

            Debug.Log("PURSUIT !!!");

            newTarget = playersList[playerSelected].transform;
            slenderMan.GetComponent<SlenderManController>().RpcSelectTarget(newTarget.position);

        }
    }



}
