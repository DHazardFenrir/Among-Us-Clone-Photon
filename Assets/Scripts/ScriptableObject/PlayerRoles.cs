using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[CreateAssetMenu(fileName = "Roles", menuName = "Game/PlayerRoles", order = 2)]
public class PlayerRoles : ScriptableObject
{
   public string[] roles = default;
    [SerializeField] string zero = "zero rol";
    string[] result;
    public int GetRol => roles.Length;
    public string GetRolCount(int index)
    {
        if (index < 0 || index > roles.Length)
        {
            Debug.LogError("Rol doesn't exist");
            return zero;
        }
    
        return roles[index];
    }

    public string GetRandomRole()
    {
        return result[Random.Range(0, roles.Length-1)];
        
    }
}
