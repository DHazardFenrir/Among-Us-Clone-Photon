using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
     private Vector3 input;
     private Rigidbody2D rb;

     private void Awake(){
         rb = GetComponent<Rigidbody2D>();
     }

     private void Update(){
         float h = Input.GetAxisRaw("Horizontal");
         float v = Input.GetAxisRaw("Vertical");

         input = new Vector3(h,v, 0f);
     }

     private void FixedUpdate(){
         rb.velocity = input * speed;
     }

}
