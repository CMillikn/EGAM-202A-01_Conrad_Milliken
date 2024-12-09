using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingGenerator : MonoBehaviour
{
    public GameObject stepPrefab;

    public Rigidbody playerBody;

    public bool steppedTrue;

    public PlayerMovement playerScript;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        playerScript = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playerScript.isDead != true)
        {
            if (Input.anyKey)
            {
                if ((Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.W)))
                {
                    if (!steppedTrue)
                    {
                        StartCoroutine(Stepper());
                    }
                }
            }
        }
    }

    IEnumerator Stepper()
    {
        steppedTrue = true;
        Instantiate(stepPrefab,this.transform);
        yield return new WaitForSeconds(0.33f);
        steppedTrue = false;
    }
}
