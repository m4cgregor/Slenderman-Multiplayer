using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    public GameObject slenderManPrefab;
    public Transform slenderSpawnPoint;
    public List<GameObject> playersList = new List<GameObject>();
    public GameObject slenderMan;
    public GameObject newTarget;

    public void Start()
    {
       

        if (isServer)
        {
            Debug.Log("Is the SERVER ");
            slenderMan = Instantiate(slenderManPrefab, slenderSpawnPoint.position, slenderSpawnPoint.rotation);
            NetworkServer.Spawn(slenderMan);

            InvokeRepeating(nameof(UpdateTarget), 2f, 3f);

        }
    
    }

   
    void UpdateTarget() {

            Debug.Log("Update Target");
            newTarget = PickClosestPlayer();
            slenderMan.GetComponent<SlenderManController>().RpcSetDestination(newTarget);   
    }


   
    GameObject PickClosestPlayer() {

        Debug.Log("Pick closest Player");
        float distance = Mathf.Infinity;
        GameObject pickedPlayer = null;

        foreach (GameObject _player in playersList) {

            float playerDistance = Vector3.Distance(transform.position, _player.transform.position);

            if (playerDistance < distance) {

                Debug.Log("Closer Player Found");
                distance = playerDistance;
                pickedPlayer = _player;
            
            }

        }

        return pickedPlayer;

    }

    // Joining Players
    [Command]
    public void CmdAddPlayerToList(GameObject newPlayer)
    {

        playersList.Add(newPlayer);
        Debug.Log("New Player Joined. Total players:" + playersList.Count);

    }



}
