using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;

    public int stepSelect;

    public Animator GaolerAnim;

    public bool Stepping;
    void Start()
    {
        GaolerAnim = GetComponent<Animator>();
    }

    public void PlayStep()
    {
        stepSelect = Random.Range(1, 3);
        if (stepSelect == 1)
        {
            Instantiate(step1, this.transform);
        }
        else if (stepSelect == 2)
        {
            Instantiate(step2, this.transform);
        }
        else
        {
            Instantiate(step3, this.transform);
        }
    }
}
