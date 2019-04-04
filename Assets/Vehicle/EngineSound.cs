using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EngineSound : MonoBehaviour
{
    private AudioSource sound;
    
    public AudioClip engineIdle;
    public AudioClip engineLowOn;
    public AudioClip engineLowOff;
    public AudioClip engineMediumOn;
    public AudioClip engineMediumOff;
    public AudioClip engineHighOn;
    public AudioClip engineHighOff;

    public int rpmPerGear = 30000;
    public int gears = 1;

    public float engineLevel;
    public float rpm;
                              
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        bool accelerating = Math.Abs(engineLevel) > 0.1;
        
        float percentOfGearRpm = rpm/rpmPerGear;
        sound.pitch = 0.3f + percentOfGearRpm;
        if (accelerating)
        {
            sound.clip = engineMediumOn;
        }                
        else
        {
            sound.clip = engineMediumOff;
        }
        
        if(!sound.isPlaying)
            sound.Play();
        
    }
}
