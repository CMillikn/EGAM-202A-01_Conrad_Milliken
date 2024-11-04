using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishPower : MonoBehaviour
{
    public BarImpulse barCode;
    public TextMeshProUGUI fishText;
    public float fishScore;

    void Update()
    {
        barCode = FindObjectOfType<BarImpulse>();
        if (barCode != null)
        {
            fishScore = Mathf.Round(barCode.fishScore * 10)/10;
            fishText.text = "Fish Power: " + fishScore;
        }
    }
}
