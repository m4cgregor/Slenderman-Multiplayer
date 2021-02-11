using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    
    public List<GameObject> playersList = new List<GameObject>(); // Lista de jugadores

    public GameObject slenderManPrefab; // Prefab para instanciar el Slender
    private Transform slenderSpawnPoint; // Posicion inicial Slender
    private GameObject slenderMan;  // Objeto para guardar el Slender instanciado
    public GameObject newTarget; // Nuevo objetivo a perseguir
    public float closestPlayerCheckInterval; // cada cuanto tiempo busca el jugador mas cercano

    public void Start()
    {
        closestPlayerCheckInterval = 3F;

        if (isServer)
        {
            Debug.Log("Is the SERVER ");
            slenderSpawnPoint = GameObject.Find("SlenderSpawnPoint").transform; // busca el spawn point
            slenderMan = Instantiate(slenderManPrefab, slenderSpawnPoint.position, slenderSpawnPoint.rotation); // instancia el slender
            NetworkServer.Spawn(slenderMan); // lo spawnea en todos los clientes


            InvokeRepeating(nameof(UpdateTarget), 2f, closestPlayerCheckInterval);

        }
    
    }

   
    void UpdateTarget() {

            Debug.Log("Update Target");
            newTarget = GetClosestPlayer();
            slenderMan.GetComponent<SlenderManController>().RpcSetTarget(newTarget);   
    }
   
    GameObject GetClosestPlayer() {

        Debug.Log("Pick closest Player");

        float minDistance = Mathf.Infinity;
        GameObject closestPlayer = null;

        foreach (GameObject _player in playersList) {

            float playerDistance = Vector3.Distance(slenderMan.transform.position, _player.transform.position);

            if (playerDistance < minDistance) {

                Debug.Log("Closer Player Found");
                minDistance = playerDistance;
                closestPlayer = _player;
            
            }

        }

        return closestPlayer;

    }

    // Joining Players
    [Command]
    public void CmdAddPlayerToList(GameObject newPlayer)
    {

        playersList.Add(newPlayer);
        Debug.Log("New Player Joined. Total players:" + playersList.Count);

    }



}
