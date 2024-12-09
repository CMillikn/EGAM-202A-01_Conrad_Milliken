using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTag : MonoBehaviour
{
    public int keysRequired;

    private void Awake()
    {
        keysRequired = 1;
    }
}
