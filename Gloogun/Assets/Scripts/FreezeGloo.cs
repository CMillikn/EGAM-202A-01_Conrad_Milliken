using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FreezeGloo : MonoBehaviour
{
    public Rigidbody GlooRB;
    public GameObject GlooSplash;
    public AudioSource GlooSplat;
    public bool GlooDecay;
    public float GlooAutokill;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.GetComponent<GlooTag>() != null)&&(!GlooDecay))
        {
            GlooSplat.pitch = UnityEngine.Random.Range(0.3f, 0.75f);
            GlooSplat.Play();
            GlooRB.isKinematic = true;
            Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0,90,0));
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if ((GlooRB.isKinematic != true) && !GlooDecay)
            {
                GlooSplat.Play();
                GlooRB.isKinematic = true;
                Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0, 90, 0));
            }
        }

        if (GlooRB.isKinematic)
        {
            StartCoroutine(glooUnfreeze());
        }
        if (GlooDecay)
        {
            GlooRB.isKinematic = false;
            this.transform.localScale = new Vector3(this.transform.localScale.x - 0.01f, this.transform.localScale.y - 0.01f, this.transform.localScale.z - 0.01f);
            if (this.transform.localScale.x < 0.01)
            {
                Instantiate(GlooSplash, this.transform.position, Quaternion.Euler(0, 90, 0));
                Destroy(this);
            }
        }

        IEnumerator glooUnfreeze()
        {
            yield return new WaitForSeconds(10);
            GlooDecay = true;
        }
        GlooAutokill = GlooAutokill + Time.deltaTime;
        if (GlooAutokill > 20)
        {
            StartCoroutine(glooUnfreeze());
        }
    }
}
