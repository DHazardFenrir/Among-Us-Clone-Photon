
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
     [SerializeField] Color[] colors = default;
     [SerializeField] TMP_Text nickLabel = default;
    SpriteRenderer spriteRenderer;
  

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine){
            GetComponent<CharacterController>().enabled = false;
            
            GetComponent<PlayerInputHandler>().enabled = false;

            Killer killer = GetComponent<Killer>();
            if (killer != null) killer.enabled = false;
        }else //its mine!
        {
           var index = Random.Range(0, colors.Length);
           photonView.RPC("SetColorIndex", RpcTarget.AllBuffered, index);
        }
        SetNickname();
    }

    [PunRPC]
   public void SetColorIndex(int index)
   {
       spriteRenderer.material.SetColor("_MainColor", colors[index]);
     
   }

   public void SetNickname()
   {
      nickLabel.text = photonView.Owner.NickName;
   }
}
