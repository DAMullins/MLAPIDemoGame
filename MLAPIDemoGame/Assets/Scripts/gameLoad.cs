using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class gameLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameLoaded();
    }


    void gameLoaded()
    {

        GameObject lP = null;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var p in players)
        {
            if (p.GetComponent<NetworkedBehaviour>().IsLocalPlayer)
            {
                lP = p;
            }
        }
        if (lP != null)
        {
            lP.GetComponentInChildren<lobbyScript>().spawnPlayer();
        }
    }

}
