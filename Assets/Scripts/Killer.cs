
using UnityEngine;
using Photon.Pun;


public class Killer : MonoBehaviourPunCallbacks
{
   

    
    void Update(){
        if(Input.GetKeyDown(KeyCode.X))
        {
            TryToKill();
        }
    }
   public void TryToKill()
   {
       var killables = FindObjectsOfType<Killeable>();
       for(int i=0; i < killables.Length; i++)
       {
           if(killables[i].photonView.IsMine) continue;
           //killables[i].Kill();
           killables[i].photonView.RPC("Kill", RpcTarget.All);
           break;
       }
   }


}
