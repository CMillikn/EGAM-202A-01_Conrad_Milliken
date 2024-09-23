using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "killplane")
        {
            Debug.Log("oobetiy boobity");
            SceneManager.LoadScene(0);
        }
    }
}
