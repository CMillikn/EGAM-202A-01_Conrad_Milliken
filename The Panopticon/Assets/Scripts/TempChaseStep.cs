using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempChaseStep : MonoBehaviour
{
    public AudioSource Step;
    void Awake()
    {
        Step = GetComponent<AudioSource>();
        Step.pitch = Random.Range(0.8f, 1.1f);
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
}
