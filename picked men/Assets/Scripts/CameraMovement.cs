using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float transAmount;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (transAmount * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (transAmount * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + (transAmount * Time.deltaTime), this.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - (transAmount * Time.deltaTime), this.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.Rotate(0, 90 ,0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Rotate(0, -90, 0);
        }
    }
}
