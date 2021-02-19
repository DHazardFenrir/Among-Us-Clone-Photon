using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GhostPlayer : MonoBehaviourPun
{
    private void Start()
    {
     

      

        if (photonView.IsMine)
        {
           var ghost =FindObjectsOfType<GhostPlayer>();
            for(int i=0; i < ghost.Length; i++)
            {
                ghost[i].ActivateRenderers(true);
            }


        }
        else
        {
            bool isThisClientGhost = FindObjectOfType<GameNetworkManager>().MyPlayer.GetComponent<PlayerInputHandler>().IsGhost;
            if (!isThisClientGhost)
            {
                //Hide Ghost.
                ActivateRenderers(false);
            }
          
        }
    }

    public void ActivateRenderers(bool value)
    {
        GetComponent<SpriteRenderer>().enabled = value;
        GetComponentInChildren<TMP_Text>().enabled = value;

    }
}
