using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;

public class ReportManager : MonoBehaviour, IOnEventCallback
{
    [SerializeField] GameObject chatObject = default;
    [SerializeField] Chat chat;
    [SerializeField] VoteScreen voteScreen = default;
    private void OnEnable() => PhotonNetwork.AddCallbackTarget(this);
    private void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);

    private void Start()
    {
        chatObject.SetActive(false);
    }


    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if(eventCode == NetworkingEventsCodes.ReportBodyEventCode)
        {
            object data = photonEvent.CustomData;
            voteScreen.CreatePlayerRows();
            chat.StartChat();
            chatObject.SetActive(true);
        }
    }
}
