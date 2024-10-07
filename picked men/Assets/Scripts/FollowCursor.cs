using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public Camera myCamera;

    public GameObject indicator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Ray mouseRay = myCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
        {
            indicator.transform.position = hitInfo.point;
        }
    }
}
