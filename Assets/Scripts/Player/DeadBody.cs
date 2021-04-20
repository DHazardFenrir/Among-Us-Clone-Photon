using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeadBody : MonoBehaviour
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
    public void SetColorIndex(int index)
    {



        spriteRenderer.material.SetColor("_MainColor", customizations.GetColor(index));

    }


}
