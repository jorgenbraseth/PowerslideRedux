using System;
using UnityEngine;
using UnityEngine.Networking;

public class Missile : NetworkBehaviour
{

    [Range(0,25)]
    public float explosionRange = 2;

    public GameObject explosionEffect;
    public String spawnedBy;

    public float speed = 15;
    public float force = 150;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && player.playerName == spawnedBy)
            return;
        
        if(isServer)
            RpcExplode();
    }

    [ClientRpc]
    private void RpcExplode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRange);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, explosionPos, explosionRange, 1F, ForceMode.Impulse);
            }
        }

        var explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        NetworkServer.Spawn(explosion);
        NetworkServer.Destroy(gameObject);
        Destroy(explosion, 5);
    }
}
