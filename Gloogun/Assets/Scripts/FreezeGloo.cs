using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGloo : MonoBehaviour
{
    public Rigidbody GlooRB;
    private void OnCollisionEnter(Collision collision)
    {
        GlooRB.isKinematic = true;
    }
}
