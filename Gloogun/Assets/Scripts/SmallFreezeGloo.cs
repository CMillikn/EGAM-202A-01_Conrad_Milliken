using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFreezeGloo : MonoBehaviour
{
    public Rigidbody GlooRB;
    public GameObject GlooSplash;
    public AudioSource GlooSplat;
    public bool GlooDecay = false;
    public float GlooAutokill;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GlooTag>() != null)
        {
            if ((collision.rigidbody.isKinematic == true) && (!GlooDecay))
            {
                GlooRB.isKinematic = true;
                Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0, 90, 0));
            }
        }
    }

    public void FixedUpdate()
    {
        if (GlooRB.isKinematic == true)
        {
            StartCoroutine(glooUnfreeze());
        }
        if (GlooDecay == true)
        {
            GlooRB.isKinematic = false;
            this.transform.localScale = new Vector3 (this.transform.localScale.x - 0.01f, this.transform.localScale.y - 0.01f, this.transform.localScale.z - 0.01f);
            if (this.transform.localScale.x < 0.01)
            {
                Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0, 90, 0));
                Destroy(this);
            }
        }
        GlooAutokill = GlooAutokill + Time.deltaTime;
        if (GlooAutokill > 20)
        {
            StartCoroutine(glooUnfreeze());
        }
    }

    IEnumerator glooUnfreeze()
    {
        yield return new WaitForSeconds(5);
        GlooDecay = true;
    }

}
