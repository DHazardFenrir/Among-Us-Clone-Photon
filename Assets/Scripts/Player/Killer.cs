
using UnityEngine;
using Photon.Pun;


public class Killer : MonoBehaviourPunCallbacks
{

    

    
    
   public void TryToKill()
   {
     
       var killeables = FindObjectsOfType<Killeable>();
        Transform[] other = new Transform[killeables.Length];

        for (int i=0; i< other.Length;i++)
        {
            other[i] = killeables[i].transform;
            float minDistance = Vector3.Distance(other[i].position, transform.position);
            if (minDistance < 1)
            {

                if (killeables[i].photonView.IsMine) continue;
                killeables[i].photonView.RPC("Kill", RpcTarget.All);

            }

        }

        
       
       
   }


}
