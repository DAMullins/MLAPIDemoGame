using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.SceneManagement;

public class lobbyScript : NetworkedBehaviour
{

    public void startClicked()
    {
        InvokeServerRpc(startSceneSwitch);
    }

    public void kickClicked()
    {
        //kick highlighted client if not the host and called by the host
    }
    public void exitClicked()
    {
        //shut down server. Return to main menu
    }
    public void characterChanged()
    {
        //update character text
    }


    [ServerRPC]
    void startSceneSwitch()
    {
        NetworkSceneManager.SwitchScene("game");
    }



}
