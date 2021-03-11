using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customizations", menuName = "Game/PlayerCustomization", order = 1)]
public class PlayerCustomizations : ScriptableObject
{
    [SerializeField] Color[] colors = default;

    public int ColorCount => colors.Length;

    public Color GetColor(int index)
    {
        if(index < 0 || index > colors.Length)
        {
            Debug.LogError("Index color doesn't exist");
            return Color.magenta;
        }
        return colors[index];
    }
   
}
