using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;


public class NetworkMan : NetworkedBehaviour
{
    public int gameState = 0; //Variable to determine which gamestate we are in (0 - not yet hosted, 1 - Lobby, 2 - In game)

    private void Start()
    {
        NetworkingManager.Singleton.OnClientConnectedCallback += ClientConnected;
        NetworkingManager.Singleton.OnClientDisconnectCallback += ClientDisconnected;
    }


    public void spawnPlayer(ulong cID)
    {
        
    }

    private void ClientConnected(ulong clientId)
    {
        //Add clientID from dict
        Debug.Log($"I'm connected {clientId}");
        //Check Game State
        if(gameState == 2)
        {
            inGameConnect(clientId);
        }


    }

    private void ClientDisconnected(ulong clientId)
    {
        //Remove clientID from dict

    }

    void inGameConnect(ulong cID)
    {
        //Spawn inGameJoin Prefab
    }


}
