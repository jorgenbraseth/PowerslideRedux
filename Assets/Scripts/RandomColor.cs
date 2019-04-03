using UnityEngine;
using UnityEngine.Networking;

public class RandomColor : NetworkBehaviour
{
    public int materialIndex;
    public MeshRenderer randomizedRenderer;
    
    private void Awake()
    {        
        if (randomizedRenderer == null)
            return;
        
        var color = new Color(Random.Range(0.1F,1F),Random.Range(0.1F,1F),Random.Range(0.1F,1F),1);
        randomizedRenderer.materials[materialIndex].color = color;
    }
}
