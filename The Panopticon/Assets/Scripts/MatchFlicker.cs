using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFlicker : MonoBehaviour
{
    public Light matchLight;

    public float matchVar;
    public float matchRandom;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            player = other.gameObject;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
        if (matchVar > 0)
        {
            matchLight.intensity = matchVar - Random.Range(-matchRandom, matchRandom);
            matchVar = matchVar - (Time.deltaTime*10);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
