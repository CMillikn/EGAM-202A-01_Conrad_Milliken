using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHeldDown;
    public GameObject Tank;
    public float droneSpeed;
    public float droneVolume = 0;
    public AudioSource droneMotorSound;
    public Camera playerView;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeldDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isHeldDown = false;
    }
    public void FixedUpdate()
    {
        droneMotorSound.volume = droneVolume;
        droneMotorSound.pitch = droneSpeed;
        if (isHeldDown)
        {
            Tank.transform.Translate(0,0,0.03f);
            if (droneSpeed < 0.8f)
            {
                droneSpeed = droneSpeed + 0.1f;
            }
            if (droneSpeed > 0.8f)
            {
                droneSpeed = 0.8f;
            }
            if (droneVolume < 0.8f)
            {
                droneVolume = droneVolume + 0.2f;
            }
            if (droneVolume > 0.8f)
            {
                droneVolume = 0.8f;
            }
        }
        else
        {
            if (droneSpeed > 0)
            {
                droneSpeed = droneSpeed - 0.05f;
            }
            if (droneSpeed < 0)
            {
                droneSpeed = 0;
            }
            if (droneVolume > 0)
            {
                droneVolume = droneVolume - 0.1f;
            }
            if (droneVolume < 0)
            {
                droneVolume = 0;
            }
        }
    }
}
