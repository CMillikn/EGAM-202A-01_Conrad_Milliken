using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }
}
