using UnityEngine;
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.Events;
using Random = UnityEngine.Random;
public class ColorDeathBody : MonoBehaviourPunCallbacks
{
    [SerializeField] PlayerCustomizations customizations;
    
    

    SpriteRenderer spriteRenderer;

   
    //Assign Color from Alive body to the death body of the crewmate. 
    //Cannot use PhotonView. 
    //Unique Color. 


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {

        int result = Random.Range(0, customizations.ColorCount);

        spriteRenderer.material.SetColor("_MainColor",customizations.GetColor(result));
           
    }

    
}
