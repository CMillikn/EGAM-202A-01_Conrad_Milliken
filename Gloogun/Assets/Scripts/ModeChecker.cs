using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeChecker : MonoBehaviour
{
    public GameObject glooGun;
    public GlooGun gunScript;
    public TextMeshProUGUI modeText;
    public string modeName;

    void Awake()
    {
        modeText = GetComponent<TextMeshProUGUI>();
        gunScript = glooGun.GetComponent<GlooGun>();
    }

    void Update()
    {
        modeText.SetText(modeName);
        if (gunScript.prefabChooser == 0)
        {
            modeName = "Current Mode: Large Ball";
        }
        if (gunScript.prefabChooser == 1)
        {
            modeName = "Current Mode: Foam Spray";
        }
    }
}
