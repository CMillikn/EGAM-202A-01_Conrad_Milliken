using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlooGun : MonoBehaviour
{
    public Transform launchTransform;
    public Transform playerTransform;
    public float launchForce;
    public GameObject ballPrefab;
    public GameObject glooSplashPrefab;
    public float ballSize = 0;
    public float increaseSpeed = 1;
    public AudioSource shootSound;

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (ballSize < 1.5f)
            {
                ballSize = ballSize + increaseSpeed * Time.deltaTime;
            }
            else
            {
                ballSize = 1.5f;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (ballSize > 0.5f)
            {
                shootSound.pitch = UnityEngine.Random.Range(0.75f, 1f);
                shootSound.Play();
                GameObject newObject = Instantiate(ballPrefab, launchTransform.position, new Quaternion (playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z, playerTransform.localRotation.w));
                GameObject partSys = Instantiate(glooSplashPrefab, launchTransform.position, new Quaternion(playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z, playerTransform.localRotation.w));
                newObject.transform.localScale = new Vector3(ballSize, ballSize, ballSize);

                Rigidbody objRb = newObject.GetComponent<Rigidbody>();
                //StartCoroutine(glooSplash(partSys));
                if (objRb)
                {
                    objRb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
                }
                ballSize = 0;
            }
            else
            {
                ballSize = 0;
            }
        }
    }
}
