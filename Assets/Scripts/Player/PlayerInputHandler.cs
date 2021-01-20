using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInputHandler : MonoBehaviourPunCallbacks
{
    Killer playerKiller;
    public Vector2 input {get; set;}
    void Awake()
    {
       playerKiller = GetComponent<Killer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputKill();
    }
   
   void InputKill(){
       if(Input.GetKeyDown(KeyCode.X))
       {
           playerKiller.TryToKill();
       }
   }

   public void InputMove()
   {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

        input = new Vector2(h,v).normalized;
   }
}
