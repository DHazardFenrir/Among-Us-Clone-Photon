﻿using UnityEngine;
using Photon.Pun;

public class PlayerMovementSyncView : MonoBehaviourPun, IPunObservable
{
    private Vector3 lastNetowrkPosition;
    private Vector3 lastNetowrkInput;

    private Rigidbody2D rb;

    private CharacterController playerController;
    private SpriteRenderer spriteRenderer;

    private PlayerInputHandler playerInput;
    private PlayerAnimation animationController;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        playerController = GetComponent<CharacterController>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        playerInput= GetComponent<PlayerInputHandler>();
        animationController = GetComponent<PlayerAnimation>();
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            //Envia datos
            stream.SendNext(playerInput.MoveInput);
            stream.SendNext(rb.position);
        }
        else
        {
            //Lee datos
            lastNetowrkInput = (Vector3)stream.ReceiveNext();
            lastNetowrkPosition = (Vector2)stream.ReceiveNext();
        }
    }

    private void FixedUpdate()
    {
        if(photonView.IsMine)
        {
            if(lastNetowrkInput.x != 0 || lastNetowrkInput.y != 0)
            {
                if(lastNetowrkInput.x < 0)
                {
                    spriteRenderer.flipX = true;
                }

                rb.position = Vector2.MoveTowards(rb.position, lastNetowrkPosition, Time.fixedDeltaTime * 2);
                rb.velocity = lastNetowrkInput * playerController.Speed;
                playerController.Move(lastNetowrkInput);
            }
            else
            {
                rb.position = lastNetowrkPosition;
            }
            animationController.MoveAnimation(lastNetowrkInput);
        }
    }
}
