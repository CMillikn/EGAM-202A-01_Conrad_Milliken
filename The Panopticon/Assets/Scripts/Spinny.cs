using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : MonoBehaviour
{
    public float SpinnerSpeed;
    void FixedUpdate()
    {
        this.transform.localEulerAngles = new Vector3 (0,this.transform.localEulerAngles.y+SpinnerSpeed,0);
    }
}
