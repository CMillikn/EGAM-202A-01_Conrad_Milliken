using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CameraFlash : MonoBehaviour, IPointerDownHandler
{
    public bool recentBlast;
    public Light cameraLight;
    public float cameraIntense;
    public float cameraSpeed;
    public float blankSpeed;
    public AudioSource cameraSound;
    public AudioSource thudWin;
    public GameObject blankScreen;
    public GameObject drone;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (recentBlast==false)
        {
            onWinPlane();
            recentBlast = true;
            cameraSound.Play();
            StartCoroutine(StartCamera());
            if (onWinPlane())
            {
                StartCoroutine(EndGame());
            }
        }
    }

    void FixedUpdate()
    {
        Camera();
    }

    public IEnumerator StartCamera()
    {
        cameraIntense = 10;
        blankSpeed = 1;
        yield return new WaitForSeconds(3);
        recentBlast=false;
    }

    public IEnumerator EndGame()
    {
        thudWin.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public bool onWinPlane()
    {
        if (drone.transform.position.y <= -40)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Camera()
    {
        cameraLight.intensity = cameraIntense;
        blankScreen.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0, 0, blankSpeed);
        if (cameraIntense > 0)
        {
            cameraIntense = cameraIntense - cameraSpeed;
        }
        if (cameraIntense < 0)
        {
            cameraIntense = 0;
        }
        if (blankSpeed > 0)
        {
            blankSpeed = blankSpeed - 0.05f;
        }
        if (blankSpeed < 0)
        {
            blankSpeed = 0;
        }
    }
}
