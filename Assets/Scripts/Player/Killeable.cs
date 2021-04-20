
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Killeable : MonoBehaviourPunCallbacks
{  

    [SerializeField] GameObject deathbodyPrefab;







    [PunRPC]
    public void Kill()
    {
        
        GameObject deathBodyObject = Instantiate(deathbodyPrefab, transform.position, transform.rotation);
        DeadBody deadBody = deathBodyObject.GetComponent<DeadBody>();

        Hashtable hashtable = this.photonView.Owner.CustomProperties;
        int indexColor = (int)hashtable["ColorIndex"];
        deadBody.SetColorIndex(indexColor);


        if (photonView.IsMine)
        {

            FindObjectOfType<GameNetworkManager>().SpawnGhost(transform.position);
        }
        Destroy(this.gameObject);
       

       




    }


   
   
  
}

