using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ChatUser : MonoBehaviourPun
{

    public void SendRPC(string message)
    {
        photonView.RPC("SendToChatRPC", RpcTarget.AllBuffered, message);
    }
    [PunRPC]
    private void SendToChatRPC(string message)
    {
        FindObjectOfType<Chat>().CreateMessage(Color.black, "nickname place holder", message);
    }

   
}
