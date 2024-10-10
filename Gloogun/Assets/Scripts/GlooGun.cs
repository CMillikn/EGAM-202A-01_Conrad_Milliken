using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlooGun : MonoBehaviour
{
    public Transform launchTransform;
    public float launchForce;
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newObject = Instantiate(ballPrefab, launchTransform.position, Quaternion.identity);

            Rigidbody objRb = newObject.GetComponent<Rigidbody>();
            if (objRb)
            {
                objRb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
            }
        }
    }
}
