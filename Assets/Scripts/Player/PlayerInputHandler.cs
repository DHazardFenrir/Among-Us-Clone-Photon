using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInputHandler : MonoBehaviourPunCallbacks
{
    Killer playerKiller;
    CharacterController characterController;
    public Vector2 MoveInput {get; set;}
    private PlayerAnimation animationController;
    void Awake()
    {
       playerKiller = GetComponent<Killer>();
       characterController = GetComponent<CharacterController>();
       animationController = GetComponent<PlayerAnimation>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillInput();
        MovementInput();
    }
   
   void KillInput(){
       if(Input.GetKeyDown(KeyCode.X))
       {
           playerKiller.TryToKill();
       }
   }

   public void MovementInput()
   {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

        MoveInput = new Vector2(h,v).normalized;
      
   }

   private void FixedUpdate()
   {
      characterController.Move(MoveInput);
      animationController.MoveAnimation(MoveInput);
   }
}
