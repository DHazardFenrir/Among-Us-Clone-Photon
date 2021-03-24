using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;

public class ReportManager : MonoBehaviour, IOnEventCallback
{
    [SerializeField] GameObject chatObject = default;
    private void OnEnable() => PhotonNetwork.AddCallbackTarget(this);
    private void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);

   

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if(eventCode == NetworkingEventsCodes.ReportBodyEventCode)
        {
            object data = photonEvent.CustomData;
            chatObject.GetComponentInChildren<Chat>().CleanChat();
            chatObject.SetActive(true);
        }
    }
}
