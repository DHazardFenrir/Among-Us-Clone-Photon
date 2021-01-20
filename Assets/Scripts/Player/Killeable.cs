
using UnityEngine;
using Photon.Pun;

public class Killeable : MonoBehaviourPunCallbacks
{  [PunRPC]
    public void Kill(){
        Destroy(this.gameObject);
    }
}
