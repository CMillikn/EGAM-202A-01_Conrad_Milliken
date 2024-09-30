using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CameraClicker : MonoBehaviour
{
    public Camera myCamera;

    public float spherecastRadius = 0.2f;

    public Transform clickHandleCenter;
    public Transform clickHandlePoint;

    public NavMeshAgent agent;

    private NavAgent dudeActive;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = myCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                NavAgent dude = hitInfo.transform.GetComponent<NavAgent>();
                if (dude != null)
                {
                    dude.SetDudeActive(true);
                    dudeActive = dude;
                }
                else if (dudeActive != null)
                {
                    dudeActive.SetDudeTarget(hitInfo.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (dudeActive != null)
            {
                dudeActive.SetDudeActive(false);
                dudeActive = null;
            }
        }
    }
}
