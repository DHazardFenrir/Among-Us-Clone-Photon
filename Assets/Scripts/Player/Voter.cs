using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Voter : MonoBehaviourPun
{
 public void SetVote(Player player)
    {
        photonView.RPC("SendVoteRPC", RpcTarget.AllBuffered, player);
    }

    [PunRPC]
    private void SendVoteRPC(Player player)
    {
        FindObjectOfType<VoteScreen>().SetVote(photonView.Owner, player);
    }
}
