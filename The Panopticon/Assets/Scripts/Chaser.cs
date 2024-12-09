using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent jailerAgent;
    public bool inTheLight;
    public bool isStepping;
    public bool resetStep;
    public float stepWait;
    public float stepDuration;
    public float stepSpeed;
    public float gaolerAnimSpeed;

    public GameObject step1;
    public GameObject step2;
    public GameObject step3;

    public Animator GaolerAnim;

    public int stepSelect;
    public Collider killBox;

    private void Awake()
    {
        jailerAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        GaolerAnim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (!inTheLight)
        {
            if (isStepping)
            {
                GaolerAnim.speed = gaolerAnimSpeed;
                StartCoroutine(MovementBurst());
            }
            ChaseState();
        }
        else
        {
            GaolerAnim.speed = 0;
            StayState();
        }
    }

    public void ChaseState()
    {
        //become lethal
        killBox.enabled = true;

        //locate player
        Vector3 playerLoc = player.transform.position;  

        //chase player
        jailerAgent.destination = playerLoc;
    }

    public void StayState()
    {
        //become inert
        killBox.enabled = false;

        //stay still
        jailerAgent.destination = this.transform.position;
        jailerAgent.speed = 0;
    }

    IEnumerator MovementBurst()
    {
        isStepping = false;
        jailerAgent.speed = stepSpeed;
        yield return new WaitForSeconds(stepDuration);
        jailerAgent.speed = 0;
        yield return new WaitForSeconds(stepWait);
        isStepping=true;
    }

    private void OnTriggerEnter(Collider beam)
    {
        if (beam.GetComponent<BeamTag>() != null)
        {
            inTheLight = true;
        }
    }

    private void OnTriggerStay(Collider beam)
    {
        if (beam.GetComponent <BeamTag>() != null)
        {
            inTheLight=true;
        }
        else if (beam.GetComponent<DarknessTag>() != null) 
        {
            inTheLight=false;
        }
    }
}
