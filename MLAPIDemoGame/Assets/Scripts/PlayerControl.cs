using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PlayerControl : NetworkedBehaviour
{
    CharacterController cc;
    
    [SerializeField]
    Camera cam;

    [SerializeField]
    Transform camObj;



    float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {        
        if (IsOwner)
        {
            cc = GetComponent<CharacterController>();
            cam.GetComponent<Camera>().enabled = true;
            cam.GetComponent<AudioListener>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            MovePlayer();
        }

    }


    void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move = move.normalized;
        move = transform.TransformDirection(move);

        cc.Move(move * Time.deltaTime * 5f);


        transform.Rotate(0, Input.GetAxisRaw("Mouse X"), 0);
        pitch += Input.GetAxisRaw("Mouse Y");
        pitch = Mathf.Clamp(pitch, -50f, 50f);
        camObj.localRotation = Quaternion.Euler(0, -90, pitch);
        
    }
}
