using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int score;
    public bool fireWin = false;
    public bool zapWin = false;
    public bool waterWin = false;

    void Start()
    {
        score = 0;
    }


    void Update()
    {
        if ((fireWin==true) && (waterWin==true) && (zapWin==true))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.tag == "red")
        {
            fireWin = true;
        }
        if (col.tag == "blue")
        {
            waterWin = true;
        }
        if (col.tag == "yellow")
        {
            zapWin = true;
        }
    }
}
