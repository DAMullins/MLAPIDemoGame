using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class loadScripts : NetworkedBehaviour
{
    public void lobbyScreenLoad()
    {
        //get connected clients list
        //update display
    }

    public void gameLoad()
    {
        //spawn clients based on params


    }
    public void gameLoaded()
    {

        GameObject lP = null;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(var p in players)
        {
            if (p.GetComponent<NetworkedBehaviour>().IsLocalPlayer)
            {
                lP = p;
            }
        }
        if(lP != null)
        {
            lP.GetComponentInChildren<lobbyScript>().spawnPlayer();
            //lP.GetComponent<lobbyScript>().spawnPlayer();
        }
    }
}
