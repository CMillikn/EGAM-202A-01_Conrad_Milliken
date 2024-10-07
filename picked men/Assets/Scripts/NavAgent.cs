using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform activeIndicator;
    public Transform targetIndicator;

    public bool hitTreasure;

    public void SetDudeActive(bool dudeActive)
    {
        activeIndicator.gameObject.SetActive(dudeActive);
        agent.enabled = true;
    }

    public void SetDudeTarget(Vector3 position)
    {
        agent.enabled = true;
        targetIndicator.gameObject.SetActive(true);
        targetIndicator.position = position;

        agent.SetDestination(position);
    }

    void Update()
    {
        Vector3 ourPosition = transform.position;
        Vector3 targetPosition = targetIndicator.position;

        Vector3 delta = ourPosition - targetPosition;
        if (delta.magnitude < 0.1f)
        {
            targetIndicator.gameObject.SetActive(false);
            agent.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "treasure")
        {
            hitTreasure = true;
            this.transform.parent = col.transform;
            //agent.enabled = false;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "treasure")
        {
            hitTreasure=false;
            this.transform.SetParent(null);
            //agent.enabled = true;
        }
    }
}
