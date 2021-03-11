using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class delPlayer : NetworkedBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!IsLocalPlayer)
        {
            gameObject.SetActive(false);
        }
        //Destroy(gameObject);
    }

}
