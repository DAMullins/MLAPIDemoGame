using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class gameLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkingManager.Singleton.GetComponent<loadScripts>().gameLoaded();
    }


}
