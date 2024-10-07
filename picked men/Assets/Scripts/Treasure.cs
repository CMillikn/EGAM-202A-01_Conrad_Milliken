using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Treasure : MonoBehaviour
{
    //Create list to have pikmin in
    public ArrayList numberOfPickmen = new ArrayList();

    public NavMeshAgent treasureNav;

    public enum walkState {idle,moving}
    public walkState currentState;

    public Transform activeIndicator;
    public Transform targetIndicator;

    //Triggers on collision enter

    public void Start()
    {
        currentState = walkState.idle;
        treasureNav = this.GetComponent<NavMeshAgent>();
        treasureNav.enabled = true;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "red" || col.tag == "blue" || col.tag == "yellow")
        {
            numberOfPickmen.Add(col.tag);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "red" || col.tag == "blue" || col.tag == "yellow")
        {
            numberOfPickmen.Remove(col.tag);
        }
    }

    public void SetTreasureActive(bool treasureActive)
    {
        activeIndicator.gameObject.SetActive(treasureActive);
        
    }

    public void SetTreasureTarget(Vector3 position)
    {
        if (currentState == walkState.moving)
        {
            
            targetIndicator.gameObject.SetActive(true);
            targetIndicator.position = position;

            //treasureNav.SetDestination(position);
        }

    }

    public void Update()
    {
        treasureNav = this.GetComponent<NavMeshAgent>();
        treasureNav.enabled = true;
        //Destination marker wrangling
        Vector3 ourPosition = transform.position;
        Vector3 targetPosition = targetIndicator.position;

        Vector3 delta = ourPosition - targetPosition;
        if (delta.magnitude < 1f)
        {
            targetIndicator.gameObject.SetActive(false);
        }

        if (currentState == walkState.moving)
        {

        }
        else if (currentState == walkState.idle)
        {

        }


        //Checks for Pikmin count before allowing movement
        if (numberOfPickmen.Count > 2)
        {
            currentState = walkState.moving;
            gameObject.layer = 0;
            //treasureNav.enabled = true;
            NavMeshAgent PikminNavs = GetComponentInChildren<NavMeshAgent>();
            PikminNavs.enabled = false;
        }
        if (numberOfPickmen.Count <= 2)
        {
            currentState = walkState.idle;
            gameObject.layer = 2;
            //treasureNav.enabled = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            NavMeshAgent PikminNavs = GetComponentInChildren<NavMeshAgent>();
            PikminNavs.enabled = true;
        }
    }
}
