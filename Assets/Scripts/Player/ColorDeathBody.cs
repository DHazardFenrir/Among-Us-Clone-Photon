using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDeathBody : MonoBehaviour
{
    PlayerSetup actualColor;

    private void Start()
    {
        actualColor = GetComponent<PlayerSetup>();
        DeathColor();
    }

    void DeathColor()
    {
        actualColor.GetUniqueRandomColorIndex();
    }
}
