using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Treasure treasureActive;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = myCamera.ScreenPointToRay(mousePosition);
            

            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                NavAgent dude = hitInfo.transform.GetComponent<NavAgent>();
                Treasure trez = hitInfo.transform.GetComponent<Treasure>();

                if (trez != null && trez.numberOfPickmen.Count > 2)
                {
                    if (trez != null)
                    {
                        Debug.Log("selected");
                        trez.SetTreasureActive(true);
                        treasureActive = trez;
                    }
                    else if (treasureActive != null)
                    {
                        Debug.Log("moving");
                        treasureActive.SetTreasureTarget(hitInfo.point);
                    }
                    else if (dude != null)
                    {
                        dude.SetDudeActive(true);
                        dudeActive = dude;
                    }
                    else if (dudeActive != null)
                    {
                        dudeActive.SetDudeTarget(hitInfo.point);
                    }
                }
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
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = myCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                Treasure trez = hitInfo.transform.GetComponent<Treasure>();
                if (treasureActive == null)
                {
                    transform.SetParent(null);
                }
            }
        }
        
        if (dudeActive != null)
        {
            if (dudeActive.hitTreasure == true)
            {
                if (dudeActive != null)
                {
                    dudeActive.hitTreasure = false;
                    dudeActive.SetDudeActive(false);
                    dudeActive = null;
                }
            }
        }
    }
}
