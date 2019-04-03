using UnityEngine;
using UnityEngine.Networking;

public class Mine : NetworkBehaviour
{
    public float forceK = 200;
    public float explosionRadius = 2;
    

    public GameObject explosionFx;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            RpcExplode();
        }        
    }

    [ClientRpc]
    void RpcExplode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(forceK * 1000, explosionPos, explosionRadius, 4F, ForceMode.Impulse);
            }
        }

        var explosion = Instantiate(explosionFx, transform.position, Quaternion.identity);
        NetworkServer.Spawn(explosion);
        NetworkServer.Destroy(gameObject);
        Destroy(explosion, 5);                
    }
}
