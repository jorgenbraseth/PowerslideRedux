using System;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody car;        

    // Update is called once per frame
    void Update()
    {
        if (car == null)
            return;
        
        var text = GetComponent<Text>();
        var kmh = car.velocity * 3600 / 1000;
        text.text = "" + Math.Abs(Mathf.RoundToInt(Vector3.Dot(kmh, car.gameObject.transform.forward.normalized))) + " km/h";
    }
}
