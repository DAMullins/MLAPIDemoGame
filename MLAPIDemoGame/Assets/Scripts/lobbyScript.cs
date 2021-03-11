using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.SceneManagement;
using UnityEngine.UI;
using MLAPI.NetworkedVar;

public class lobbyScript : NetworkedBehaviour
{
    public Dropdown ddm;
    public GameObject mp;
    public NetworkedVarULong chork = new NetworkedVarULong(58);
    public int pS = 0;
    public void startClicked()
    {
        if (IsLocalPlayer)
        {
            if (IsHost)
            {
                InvokeServerRpc(startSceneSwitch);
            }
            else
            {
                Debug.Log("Only the host can start the game");
            }

        }
    }

    public void kickClicked()
    {
        if (IsLocalPlayer)
        {
            //kick highlighted client if not the host and called by the host
            //var pParams = NetworkingManager.Singleton.GetComponent<NetworkMan>().playerParams;
            //Debug.Log(NetworkingManager.Singleton.GetComponent<NetworkMan>().chork.Value);
            GameObject tV = GameObject.Find("Player1Char");
            GameObject tV2 = GameObject.Find("Player2Char");
            tV.GetComponent<Text>().text = OwnerClientId.ToString();
            tV2.GetComponent<Text>().text = chork.Value.ToString();
            /*
            foreach (var key in pParams.Keys)
            {
                //Debug.Log(key);

            }
            */
        }
    }

    public void exitClicked()
    {
        if (IsLocalPlayer)
        {

        }
        //shut down server. Return to main menu
    }
    public void characterChanged()
    {
        pS = ddm.GetComponent<Dropdown>().value;
    }


    [ServerRPC]
    void startSceneSwitch()
    {
        NetworkSceneManager.SwitchScene("mainGame");
    }

    [ServerRPC]
    void updateInfo(ulong cID)
    {
        chork.Value = cID;
    }

    public void spawnPlayer()
    {
        mp.SetActive(false);
        InvokeServerRpc(spawnPlayerServ, pS);
    }

    [ServerRPC]
    public void spawnPlayerServ(int pNum)
    {
        if(pNum == 0)
        {
            var pf = Resources.Load("Prefabs/Player1PreFab");
            GameObject go = (GameObject)Instantiate(pf, Vector3.zero, Quaternion.identity);
            go.GetComponent<NetworkedObject>().SpawnWithOwnership(OwnerClientId);
        }
        else
        {
            var pf = Resources.Load("Prefabs/Player2PreFab");
            GameObject go = (GameObject) Instantiate(pf, Vector3.zero,Quaternion.identity);
            go.GetComponent<NetworkedObject>().SpawnWithOwnership(OwnerClientId);
        }
        
        
    }

}
