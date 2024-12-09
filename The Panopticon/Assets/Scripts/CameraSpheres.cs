using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpheres : MonoBehaviour
{
    public float sphereSize;
    public float sphereDistance;
    public Color sphereColor;
    public Chaser jailer;
    public bool hitEnemy;
    void Update()
    {
        //Cast a sphere out, starting from THIS, with a radius of 18, send it FORWARD, return HIT, with a max distance of 58, and a layer mask of EnemyRaycast which is layer 6
        if ((Physics.SphereCast(this.transform.position, 18, transform.forward, out RaycastHit hit, 58, 6))&& hit.transform.GetComponent<Chaser>() != null)
        {
            jailer = hit.transform.GetComponent<Chaser>();
            jailer.inTheLight = true;
        }
    }
}
