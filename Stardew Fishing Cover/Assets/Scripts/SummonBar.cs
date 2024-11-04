using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBar : MonoBehaviour
{
    public bool fishTug;
    public bool isFishing;
    public bool didCatch;
    public bool died = false;
    public bool isBar;
    public bool isGreen;
    public GameObject barPrefab;
    public SpriteRenderer playerSR;

    private void Awake()
    {
        playerSR = GetComponent<SpriteRenderer>();
        fishTug = false;
        isFishing = false;
        didCatch = false;
        died = false;
        isBar = false;
        isGreen = false;
    }

    void Update()
    {
        if (died == false)
        {
            if (isFishing == false)
            {
                StartCoroutine(FishTug());
            }
            if (fishTug == true)
            {
                StartCoroutine(FishTimer());
                if (Input.GetMouseButtonDown(0))
                {
                    StopCoroutine(FishTimer());
                    playerSR.color = Color.yellow;
                    didCatch = true;
                }
            }    
        }
        if (didCatch == true)
        {
            StartCoroutine(ActivateBar());
        }
        if (isGreen == true)
        {
            StartCoroutine(GoGreenless());
            isGreen = false;
        }
    }

    IEnumerator FishTug()
    {
        isFishing = true;
        yield return new WaitForSeconds(Random.Range(4.0f, 8.0f));
        playerSR.color = Color.red;
        fishTug = true;
    }

    IEnumerator FishTimer()
    {
        yield return new WaitForSeconds(2f);
        if (didCatch == false)
        {
            playerSR.color = Color.black;
            died = true;
        }
    }

    IEnumerator ActivateBar()
    {
        yield return new WaitForSeconds(0.75f);

        if (isBar != true)
        {
            isBar = true;
            Instantiate(barPrefab, new Vector2(-4,0), Quaternion.identity);
        }
    }

    IEnumerator GoGreenless()
    {
        playerSR.color = Color.green;
        yield return new WaitForSeconds(2.5f);
        playerSR.color = Color.white;
    }
}
