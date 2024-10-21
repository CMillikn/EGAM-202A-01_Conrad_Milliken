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
    public GameObject smallBallPrefab;
    public GameObject glooSplashPrefab;
    public int prefabChooser;
    public float ballSize = 0;
    public float increaseSpeed = 1;
    public AudioSource shootSound;
    public bool reloaded = true;

    private void Awake()
    {
        reloaded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //0 is Ball
            if (prefabChooser == 0)
            {
                prefabChooser = 1;
            }
            //1 is Spray
            else if (prefabChooser == 1)
            {
                prefabChooser = 0;
            }
        }
        if (prefabChooser == 0)
        {
            if (Input.GetMouseButton(0))
            {
                shootSound.volume = 0.5f;
                launchForce = 15;
                increaseSpeed = 3;
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
                    GameObject newObject = Instantiate(ballPrefab, launchTransform.position, new Quaternion(playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z, playerTransform.localRotation.w));
                    GameObject partSys = Instantiate(glooSplashPrefab, launchTransform.position, new Quaternion(playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z, playerTransform.localRotation.w));
                    newObject.transform.localScale = new Vector3(ballSize * 1.2f, ballSize * 1.2f, ballSize * 1.2f);

                    Rigidbody objRb = newObject.GetComponent<Rigidbody>();
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
        else if (prefabChooser == 1)
        {
            shootSound.volume = 0.1f;
            launchForce = 8;
            if (Input.GetMouseButton(0))
            {
                if (reloaded == true)
                {
                    StartCoroutine(BallSpray());
                }
            }
        }

    }

    IEnumerator BallSpray()
    {

        ballSize = 0.4f;
        shootSound.pitch = UnityEngine.Random.Range(1.2f, 1.4f);
        GameObject newObject = Instantiate(smallBallPrefab, launchTransform.position, new Quaternion(playerTransform.localRotation.x + UnityEngine.Random.Range(-0.2f,0.2f), playerTransform.localRotation.y + UnityEngine.Random.Range(-0.2f, 0.2f), playerTransform.localRotation.z, playerTransform.localRotation.w));
        GameObject partSys = Instantiate(glooSplashPrefab, launchTransform.position, new Quaternion(playerTransform.localRotation.x, playerTransform.localRotation.y, playerTransform.localRotation.z, playerTransform.localRotation.w));
        newObject.transform.position = new Vector3(newObject.transform.position.x + UnityEngine.Random.Range(-0.1f, 0.1f), newObject.transform.position.y + UnityEngine.Random.Range(-0.1f, 0.1f), newObject.transform.position.z);
        newObject.transform.localScale = new Vector3(ballSize, ballSize, ballSize);
        partSys.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Rigidbody objRb = newObject.GetComponent<Rigidbody>();
        if (objRb)
        {
            objRb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
        }
        reloaded = false;
        yield return new WaitForSeconds(0.05f);
        reloaded = true;
    }
}
