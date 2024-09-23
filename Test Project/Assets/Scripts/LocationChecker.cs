using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationChecker : MonoBehaviour
{
    public float toneVolume;
    public AudioSource shepardDrone;

    public void Start()
    {
        toneVolume = 0.2f;
    }
    void FixedUpdate()
    {
        theElevation(this.transform.position.y);
    }
    public void theElevation(float height)
    {
        if (height < -10)
        {
            toneVolume = toneVolume - 0.0025f;
            shepardDrone.volume = toneVolume;
        }
    }
}
