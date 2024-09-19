using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            Tank.transform.Rotate(0, 0.45f, 0);
        }
    }
}
