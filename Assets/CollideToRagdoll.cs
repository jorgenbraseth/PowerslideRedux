using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideToRagdoll : MonoBehaviour
{
    public GameObject ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
