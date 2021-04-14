using UnityEngine;
using Photon.Pun;

public class PlayerMovementSyncView : MonoBehaviourPun, IPunObservable
{
    private Vector2 lastNetowrkPosition;
    private Vector2 lastNetowrkInput;

    private Rigidbody2D rb;

    private CharacterController playerController;


    private PlayerInputHandler playerInput;
    private PlayerAnimation animationController;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        playerController = GetComponent<CharacterController>();

 

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
            lastNetowrkInput = (Vector2)stream.ReceiveNext();
            lastNetowrkPosition = (Vector2)stream.ReceiveNext();
        }
    }

    private void FixedUpdate()
    { //Actualizacion del servidor en tu View, de objetos que no son tuyos. 
        if(!photonView.IsMine)
        {
            if(lastNetowrkInput.x != 0 || lastNetowrkInput.y != 0)
            {
               
                //Hacer el calculo para actualizar a la posicion del servidor. 
                rb.position = Vector2.MoveTowards(rb.position, lastNetowrkPosition, Time.fixedDeltaTime * 2);
                
                playerController.Move(lastNetowrkInput); 
            }
            else
            {
                //Actualiza la posicion en la que esta, a la posicion del servidor.
                rb.position = lastNetowrkPosition;
            }
            animationController.MoveAnimation(lastNetowrkInput);
        }
    }
}
