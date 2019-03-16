using UnityEngine;

public class Mine : MonoBehaviour
{
    public float forceK = 200;
    public float explosionRadius = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(forceK*1000, transform.position, explosionRadius, 5, ForceMode.Impulse);
            Destroy(gameObject);
        }        
    }
}
