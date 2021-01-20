using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmongXP.Networking;
using DG.Tweening;

namespace amongXP.UI
{
    public class ConnectingView : MonoBehaviour
    {
        [SerializeField] LaunchManager launchManager = default;
       
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            launchManager.onConnectServerStarted += ShowView;
            launchManager.onConnectServerSucced += HideView;
            launchManager.onConnectedServerFailed += HideView;
        }

        private void OnDisable()
        {
            launchManager.onConnectServerStarted -= ShowView;
            launchManager.onConnectServerSucced -= HideView;
            launchManager.onConnectedServerFailed -= HideView;
        }


        private void ShowView() { 
            canvasGroup.DOFade(1f, 0.5f);
            canvasGroup.blocksRaycasts = true;
        
        
        }

        private void HideView() { 
            
            canvasGroup.DOFade(0f, 0.5f);
            canvasGroup.blocksRaycasts = false;
        } 
    }
}

