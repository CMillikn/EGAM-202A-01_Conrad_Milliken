using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 


public class MovementPlayer : MonoBehaviour
{
    public GameObject Tank;
    public Button LeftButton;
    void Start()
    {

    }

    
    public void ButtonPressed()
    {
        Tank.transform.Rotate(0, 1, 0);
    }
}
