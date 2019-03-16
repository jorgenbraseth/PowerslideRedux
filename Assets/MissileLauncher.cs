using UnityEngine;
using UnityEngine.Networking;

public class MissileLauncher : NetworkBehaviour
{

    public Missile missilePrefab;
    public Transform spawnPos;

    public NetworkBehaviour car;    
    // Update is called once per frame
    void Update()
    {
        if (!car.isLocalPlayer) 
            return;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdShoot();
        }
    }

    [Command]
    void CmdShoot()
    {
        Missile missile = Instantiate(missilePrefab, spawnPos.position, spawnPos.rotation);
        missile.spawnedBy = GetComponent<Player>().playerName;
        NetworkServer.Spawn(missile.gameObject);
    }
}
