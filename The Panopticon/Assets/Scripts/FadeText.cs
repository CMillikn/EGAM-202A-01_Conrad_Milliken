using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    TextMeshProUGUI thisTM;

    private void Awake()
    {
        thisTM = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        thisTM.alpha = thisTM.alpha - (Time.deltaTime/4);
    }
}
