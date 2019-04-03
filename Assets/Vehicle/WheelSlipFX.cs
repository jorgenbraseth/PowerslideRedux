using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSlipFX : MonoBehaviour
{

    public ParticleSystem accelerationSmoke;

    // Update is called once per frame
    void Update()
    {
        WheelHit hit = new WheelHit();
        WheelCollider wheel = GetComponent<WheelCollider>();
        if (wheel.GetGroundHit(out hit))
        {
            if (hit.forwardSlip < -1 || hit.sidewaysSlip < -0.5 || hit.sidewaysSlip > 0.5)
            {
                StartSmoke();
            }
            else
            {
                StopSmoke();
            }               
        }
        else
        {
            StopSmoke();
        }
    }

    private void StartSmoke()
    {
        var accelerationSmokeMain = accelerationSmoke.main;
        accelerationSmokeMain.loop = true;
        accelerationSmoke.Play();
    }

    private void StopSmoke()
    {
        var accelerationSmokeMain = accelerationSmoke.main;
        accelerationSmokeMain.loop = false;
    }
}
