using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJank : MonoBehaviour
{
    public bool jibbly = true;
    public float goAmount;
    public float goDecide;
    
    void Update()
    {
        if (jibbly)
        {
            StartCoroutine(Fish());
        }
        
    }

    IEnumerator Fish()
    {
        jibbly = false;
        if (transform.position.y <= -2.8f)
        {
            goDecide = Random.Range(-1, 1);
            if (goDecide > 0)
            {
                goAmount = Random.Range(0.05f, 0.03f);
            }
            else
            {
                goAmount = 0.015f;
            }
        }
        else if ((transform.position.y > -2.8f) && transform.position.y < 2.8f)
        {
            goDecide = Random.Range(-1, 1);
            if (goDecide > 0)
            {
                goAmount = Random.Range(-0.05f, -0.03f);
            }
            else
            {
                goAmount = Random.Range(0.03f, 0.05f);
            }
        }
        else
        {
            goDecide = Random.Range(-1, 1);
            if (goDecide > 0)
            {
                goAmount = Random.Range(-0.05f, -0.03f);
            }
            else
            {
                goAmount = -0.015f;
            }
        }
        Debug.Log("waiting");
        yield return new WaitForSeconds(Random.Range(2,4));
        Debug.Log("re-energizing");
        jibbly = true;
    }


    IEnumerator FishTooLow()
    {
        yield return new WaitForSeconds(0);
        goAmount = Random.Range(0.01f, 0.05f);
    }

    IEnumerator FishTooHigh()
    {
        yield return new WaitForSeconds(0);
        goAmount = Random.Range(-0.01f, -0.05f);
    }


    public void FixedUpdate()
    {
        if (transform.position.y <= -2.8f)
        {
            transform.position = new Vector2(transform.position.x, (transform.position.y + 0.01f));
            StartCoroutine(FishTooLow());

        }
        else if ((transform.position.y > -2.8f) && transform.position.y < 2.5f)
        {
            transform.position = new Vector2(transform.position.x, (transform.position.y + goAmount));
        }
        else
        {
            transform.position = new Vector2(transform.position.x, (transform.position.y + -0.01f));
            StartCoroutine(FishTooHigh());
        }
    }

}
