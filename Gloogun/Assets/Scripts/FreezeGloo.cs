using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGloo : MonoBehaviour
{
    public Rigidbody GlooRB;
    public GameObject GlooSplash;
    public AudioSource GlooSplat;

    private void OnCollisionEnter(Collision collision)
    {
        GlooSplat.pitch = UnityEngine.Random.Range(0.3f, 0.75f);
        GlooSplat.Play();
        GlooRB.isKinematic = true;
        Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0,90,0));
    }

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (GlooRB.isKinematic != true)
            {
                GlooSplat.Play();
                GlooRB.isKinematic = true;
                Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0, 90, 0));
            }
        }
    }
}
