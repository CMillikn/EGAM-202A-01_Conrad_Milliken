using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlooDeath : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(glooSplash(this.gameObject));
    }

    public IEnumerator glooSplash(GameObject gloo)
    {
        yield return new WaitForSeconds(1);
        Destroy(gloo);
    }
}
