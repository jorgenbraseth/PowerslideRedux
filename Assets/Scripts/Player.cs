using System;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar] public String playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName = Guid.NewGuid().ToString();
        if (isLocalPlayer)
        {
            Camera.main.GetComponent<FollowCam>().follow = gameObject;
            FindObjectOfType<Speedometer>().car = GetComponent<Rigidbody>();
        }
    }
}
