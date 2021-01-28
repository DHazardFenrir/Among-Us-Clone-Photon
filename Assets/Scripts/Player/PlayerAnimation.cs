using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    private SpriteRenderer spriteRenderer = default;
    private int isWalkingAnimationId;
    void Awake()
    {
        isWalkingAnimationId = Animator.StringToHash("isWalking");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void MoveAnimation(Vector2 input)
    {
      animator.SetBool(isWalkingAnimationId, input.x !=0f || input.y !=0);

      //Flip
      bool isWalkingLeft = input.x < 0;
      bool isWalkingRight = input.y > 0;

      if(isWalkingLeft)
      {
        spriteRenderer.flipX = true;
      }else if(isWalkingRight)
      {
         spriteRenderer.flipX = false;
      }
    }
}
