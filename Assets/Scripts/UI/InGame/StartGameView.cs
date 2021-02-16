using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class StartGameView : MonoBehaviour, IOnEventCallback
{
    private CanvasGroup canvasGroup;

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void HideScreen()
    {
        canvasGroup.DOFade(0f, 1f);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if(eventCode == NetworkingEventsCodes.StartGameEventCode)
        {
            object data = photonEvent.CustomData;
            HideScreen();
            
        }
        
    }
}
