using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pets", menuName = "Game/PetsCustomizations", order = 3)]
public class Pets : ScriptableObject
{
    [SerializeField] GameObject[] pets = default;
    [SerializeField] GameObject empty = default;

    public int PetsCount => pets.Length;

    public  GameObject GetPet(int index)
    {
        if (index < 0 || index > pets.Length)
        {
            Debug.LogError("Pet doesn't exist");
            return empty;
        }
        return pets[index];
    }
}
