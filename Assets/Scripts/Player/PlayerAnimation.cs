using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    private int isWalkingAnimationId;
    void Awake()
    {
        isWalkingAnimationId = Animator.StringToHash("Walk");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void MoveAnimation(Vector2 input)
    {
      animator.SetBool(isWalkingAnimationId, input.x !=0f || input.y !=0);
    }
}
