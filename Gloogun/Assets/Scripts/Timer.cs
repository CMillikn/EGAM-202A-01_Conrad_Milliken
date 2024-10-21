using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeFloat;
    public float timeRounded;
    public int successLevel;
    public TextMeshProUGUI timeText;
    public string timeValue;
    public string timeCombined;

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (successLevel == 0)
        {
            timeFloat = timeFloat + Time.deltaTime;
            timeRounded = (Mathf.Round(timeFloat * 100)) / 100.0f;
            timeCombined = "Time: " + timeRounded;
            timeText.SetText(timeCombined);
        }

    }
}
