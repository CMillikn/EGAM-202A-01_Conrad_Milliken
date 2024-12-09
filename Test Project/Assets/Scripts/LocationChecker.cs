using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class LocationChecker : MonoBehaviour
{
    public float toneVolume;
    public AudioSource shepardDrone;
    public float rotation;
    public UnityEngine.UI.Image north;
    public UnityEngine.UI.Image south;
    public UnityEngine.UI.Image west;
    public UnityEngine.UI.Image east;


    public void Start()
    {
        toneVolume = 0.2f;
    }
    void FixedUpdate()
    {
        theElevation(this.transform.position.y);
        rotation = Mathf.DeltaAngle(this.transform.eulerAngles.y, 180);
        if ((rotation < -135))
        {
            north.enabled = true;
            south.enabled = false;
            west.enabled = false;
            east.enabled = false;
        }
        else if ((rotation >= 135))
        {
            north.enabled = true;
            south.enabled = false;
            west.enabled = false;
            east.enabled = false;
        }
        else if ((rotation < 135)&& (rotation >= 45))
        {
            north.enabled = false;
            south.enabled = false;
            west.enabled = false;
            east.enabled = true;
        }
        else if ((rotation < 45)&& (rotation >= -45))
        {
            north.enabled = false;
            south.enabled = true;
            west.enabled = false;
            east.enabled = false;
        }
        else
        {
            north.enabled = false;
            south.enabled = false;
            west.enabled = true;
            east.enabled = false;
        }
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
