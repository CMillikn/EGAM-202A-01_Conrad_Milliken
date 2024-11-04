using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarImpulse : MonoBehaviour
{
    public float impulseStrength;
    public float speedCap;
    public float fishScore;
    public bool isScoring;
    public SpriteRenderer bobRend;
    public Rigidbody2D barRB;
    public FishJank fishScript;
    public GameObject killBar;
    public GameObject player;
    public SummonBar playerScript;
    public SpriteRenderer playerSR;


    private void Awake()
    {
        fishScore = 50;
        barRB = GetComponent<Rigidbody2D>();
        bobRend = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if ((fishScore <= 100) && fishScore >= 0)
        {
            if (barRB.velocity.magnitude < speedCap)
            {
                if (Input.GetMouseButton(0))
                {
                    barRB.AddForce(transform.up * impulseStrength);
                }
            }
            else if (barRB.velocity.magnitude > speedCap)
            {
                barRB.velocity = new Vector2(0,speedCap);
            }
            if (isScoring)
            {
                fishScore = fishScore + 0.2f;
            }
            else if (!isScoring)
            {
                fishScore = fishScore - 0.3f;
            }
        }
        else
        {
            barRB.velocity = Vector2.zero;
            barRB.isKinematic = true;
        }
        if (fishScore >= 100)
        {
            StartCoroutine(SuccessfulFish());
        }
        playerScript = FindObjectOfType<SummonBar>();
        player = playerScript.gameObject;
        playerSR = player.GetComponent<SpriteRenderer>();
    }

    IEnumerator SuccessfulFish()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(killBar);
        playerScript.fishTug = false;
        playerScript.isFishing = false;
        playerScript.didCatch = false;
        playerScript.died = false;
        playerScript.isBar = false;
        playerScript.isGreen = true;
        playerSR.color = Color.green;
        playerScript.StopAllCoroutines();
        StopAllCoroutines();
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if ((fishScore <= 100) && fishScore >= 0)
        {
            fishScript = col.transform.GetComponent<FishJank>();
            if (fishScript != null)
            {
                isScoring = true;
                bobRend.color = Color.yellow;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if ((fishScore <= 100) && fishScore >= 0)
        {
            fishScript = col.transform.GetComponent<FishJank>();
            if (fishScript != null)
            {
                isScoring = false;
                bobRend.color = Color.red;
            }
        }
    }
}
