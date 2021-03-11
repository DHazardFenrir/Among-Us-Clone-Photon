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
    
    
    [SerializeField] bool isGhost = false;
    public bool IsGhost => isGhost;

    private Reporter reporter;
    void Awake()
    {
       playerKiller = GetComponent<Killer>();
       characterController = GetComponent<CharacterController>();
       animationController = GetComponent<PlayerAnimation>();
        reporter = GetComponent<Reporter>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillInput();
        MovementInput();
        ProcessReporterInput();
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

    private void ProcessReporterInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            reporter.TryToReport();
        }
    }
}
