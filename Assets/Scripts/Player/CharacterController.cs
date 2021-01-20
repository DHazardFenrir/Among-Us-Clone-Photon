using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] CharacterController characterController;
    PlayerInputHandler playerInput;
    public float Speed => speed;
    
     private Rigidbody2D rb;

     private void Awake(){
         rb = GetComponent<Rigidbody2D>();
         playerInput = GetComponent<PlayerInputHandler>();
     }

  
     private void FixedUpdate(){
         rb.velocity = playerInput.input * speed;
     }

    

}
