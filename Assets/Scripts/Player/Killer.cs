
using UnityEngine;
using Photon.Pun;


public class Killer : MonoBehaviourPunCallbacks
{
    [SerializeField] KillTrigger killTrigger = default;
    

    
    
   public void TryToKill()
   {
        if (!killTrigger.CanKill) return;
        GameObject playerToKill = killTrigger.GetNearerPlayer();
        
        if(playerToKill != null)
        {
            Killeable killeable = playerToKill.GetComponent<Killeable>();
            if (killeable.photonView.IsMine) return;
            killeable.photonView.RPC("Kill", RpcTarget.All);
        }
     
       
        
       
       
   }


}
