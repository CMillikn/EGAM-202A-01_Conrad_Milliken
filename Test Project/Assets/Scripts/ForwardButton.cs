using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHeldDown;
    public GameObject Tank;

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
        if (isHeldDown)
        {
            Tank.transform.Translate(0,0,0.03f);
        }
    }
}
