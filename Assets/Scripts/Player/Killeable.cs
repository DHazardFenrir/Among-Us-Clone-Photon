
using UnityEngine;
using Photon.Pun;

public class Killeable : MonoBehaviourPunCallbacks
{  

    [SerializeField] GameObject deathbodyPrefab;







    [PunRPC]
    public void Kill()
    {
        
        Instantiate(deathbodyPrefab, transform.position, transform.rotation);

        if (photonView.IsMine)
        {

            FindObjectOfType<GameNetworkManager>().SpawnGhost(transform.position);
        }
        Destroy(this.gameObject);
       

       




    }


   
   
  
}

