using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.SceneManagement;

public class MainMenu : NetworkedBehaviour
{
 
    public void hostGameClicked()
    {      
        NetworkingManager.Singleton.StartHost();
        InvokeServerRpc(switchToLobby);
    }
    public void joinGameClicked()
    {
        NetworkingManager.Singleton.StartClient();
    }

    [ServerRPC]
    void switchToLobby()
    {
        NetworkSceneManager.SwitchScene("lobbyScreen");
    }


}
