using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    
    public float Speed => speed;
    
     private Rigidbody2D rb;

     private void Awake(){
         rb = GetComponent<Rigidbody2D>();
        
     }

  
     public void Move(Vector2 input){
         rb.velocity = input * speed;
     }

    

}
