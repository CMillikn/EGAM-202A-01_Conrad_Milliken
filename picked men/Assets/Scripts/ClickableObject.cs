using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Renderer myRend;

    Color originalColor;
    public Color myHighlight;

    bool isHighlighted;

    public void Start()
    {
        originalColor = myRend.material.color;
    }

    public void Hover()
    {
        myRend.material.color = myHighlight;
        isHighlighted = true;
    }

    public void Update()
    {
        if (isHighlighted)
        { 
            isHighlighted = false;
            myRend.material.color=originalColor;
        }
    }
}
